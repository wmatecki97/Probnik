using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Grapevine;
using Grapevine.Server;
using Probnik.Core.DTO;
using Probnik.Presistence;

namespace Probnik.REST.Controllers
{
    public sealed class ChallengeController : RESTResource
    {
        [RESTRoute(Method = HttpMethod.GET, PathInfo = @"^/Get/Challenges/")]
        public void GetChallengesForTeam(HttpListenerContext context)
        {
            string[] parameters = context.Request.RawUrl.Replace("/Get/Challenges/", "").Split('/');

            int teamId = int.Parse(parameters[0]);
            string token = parameters[1];

            var session = SessionManager.GetSession(token);

            var unit = new UnitOfWork(session.context);

            var team = unit.Teams.GetTeamWithMethodologies(teamId);


            var result = new List<ChallengeTypeDTO>();

            foreach (var methodology in team.Methodologies)
            {
                var challenges = unit.ChallangeTypes.GetChallangeTypesForMethodology(methodology.Id.Value);
                foreach (var challangeType in challenges)
                {
                    result.Add(challangeType.ToChallengeTypeDTO());
                }
            }

            MyResponder.RespondJson(context, result);
        }

        [RESTRoute(Method = HttpMethod.GET, PathInfo = @"^/Get/AllChallenges/")]
        public void GetAllChallengeTypes(HttpListenerContext context)
        {
            string[] parameters = context.Request.RawUrl.Replace("/Get/AllChallenges/", "").Split('/');

            string token = parameters[0];

            var session = SessionManager.GetSession(token);

            var unit = new UnitOfWork(session.context);

            var result = new List<ChallengeTypeDTO>();

            var challenges = unit.ChallangeTypes.GetAll().ToList();
            foreach (var challangeType in challenges)
            {
                result.Add(challangeType.ToChallengeTypeDTO());
            }

            MyResponder.RespondJson(context, result);
        }


        [RESTRoute(Method = HttpMethod.GET, PathInfo = @"^/Get/ChallengeFor/")]
        public void GetChallengeForPerson(HttpListenerContext context)
        {
            string[] parameters = context.Request.RawUrl.Replace("/Get/ChallengeFor/", "").Split('/');

            int challengeTypeId = int.Parse(parameters[0]);
            int personId = int.Parse(parameters[1]);
            string token = parameters[2];

            var session = SessionManager.GetSession(token);
            session.context = new ProbnikContext();

            var result = new List<ChallengeDTO>();



            if (session.user.People.Any(p => p.Id == personId))
            {
                var unit = new UnitOfWork(session.context);
                var challenges = unit.Challanges.FindFull(c => c.Owner.Id == personId
                                                   && c.Task.ChallangeTypeId == challengeTypeId).ToList();
                if (challenges.Count > 0)
                {
                    var patronId = challenges[0].PatronId;
                    if(patronId.HasValue)
                        unit.Patrons.GetPatronWithPerson(patronId.Value);
                    foreach (var challenge in challenges)
                    {
                        result.Add(challenge.ToChallengeDTO());
                    }
                }
                
            }

            MyResponder.RespondJson(context, result);
        }



        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/Save/Challenge/")]
        public void SaveChallenge(HttpListenerContext context)
        {
            string[] parameters = context.Request.RawUrl.Replace("/Save/Challenge/", "").Split('/');
            string token = parameters[0];


            var session = SessionManager.GetSession(token);

            var unit = new UnitOfWork(session.context);

            var personChallengesDTO = RESTHelper.GetObject<ChallengeDTO[]>(context).ToList();
            var ChallengeTypeId = personChallengesDTO.First().Task.ChallangeTypeId;

            if (personChallengesDTO.All(c => c.Id.HasValue))
            {
                
                    SaveChanges(session, unit, personChallengesDTO);
                    MyResponder.RespondJson(context, personChallengesDTO);
                

                
            }
            else
            {
                var resultDTO = CreateChallenges(personChallengesDTO, unit);
                MyResponder.RespondJson(context, resultDTO);
            }
        }

        private static List<ChallengeDTO> CreateChallenges(List<ChallengeDTO> personChallengesDTO, UnitOfWork unit)
        {
            var tosave = new List<Challange>();
            //Utwórz
            foreach (var challengeDto in personChallengesDTO)
            {
                tosave.Add(challengeDto.ToChallenge());
            }

            unit.Challanges.AddRange(tosave);
            unit.Complete();

            var owner = personChallengesDTO.Select(p => p.Owner.Id).First();
            var tasksIds = personChallengesDTO.Select(p => p.Task.Id).ToList();

            var result = unit.Challanges.Find(c => c.OwnerId == owner && tasksIds.Any(id => c.TaskId == id)).ToList();

            var resultDTO = new List<ChallengeDTO>();
            foreach (var challange in result)
            {
                resultDTO.Add(challange.ToChallengeDTO());
            }

            return resultDTO;
        }

        private static void SaveChanges(Session session, UnitOfWork unit, List<ChallengeDTO> personChallengesDTO)
        {
            var challengesIds = personChallengesDTO.Select(pc => pc.Id);
            var challenges = unit.Challanges.Find(c => challengesIds.Any(id => id == c.Id)).ToList();

            var person = session.user.People.First(p => p.ConnectionType == ConnectionType.PersonToOwner);

            if (personChallengesDTO.All(c => c.Owner.Id == person.Id))
            {
                foreach (var challenge in personChallengesDTO)
                {
                    var toEdit = challenges.First(c => c.Id == challenge.Id);
                    bool changed = toEdit.Mission != challenge.Mission || 
                                   (challenge.Patron != null && 
                                    toEdit.PatronId != challenge.Patron.Id);
                    if (changed)
                    {
                        toEdit.Mission = challenge.Mission;
                        toEdit.State = TaskState.WaitingForAcceptation;
                        if (challenge.Patron != null)
                            toEdit.PatronId = challenge.Patron.Id;
                    }
                    
                }
            }

            if (personChallengesDTO.All(c => c.Patron != null && c.Patron.Person.Id == person.Id))
            {
                foreach (var challenge in personChallengesDTO)
                {
                    var toEdit = challenges.First(c => c.Id == challenge.Id);
                    if (toEdit.Comment != challenge.Comment)
                    {
                        toEdit.Comment = challenge.Comment;
                        toEdit.State = TaskState.Comments;
                    }
                }
            }



            unit.Complete();
        }

        [RESTRoute(Method = HttpMethod.GET, PathInfo = @"^/Get/ChallengesForPatron/")]
        public void GetChallengesForPatron(HttpListenerContext context)
        {
            string[] parameters = context.Request.RawUrl.Replace("/Get/ChallengesForPatron/", "").Split('/');

            int patronId = int.Parse(parameters[0]);
            int personId = int.Parse(parameters[1]);
            string token = parameters[2];


            var session = SessionManager.GetSession(token);
            session.context = new ProbnikContext();

            var result = new List<ChallengeDTO>();

            if (session.user.People.Any(p => p.Id == personId && p.ConnectionType == ConnectionType.PersonToOwner))
            {
                var unit = new UnitOfWork(session.context);
                if (unit.Patrons.Find(p => p.Person.Id == personId).Count() > 0)
                {
                    var patron = unit.Patrons.GetPatronWithPerson(patronId);
                    var challenges = unit.Challanges.GetChallengesForPatron(patronId);
                    foreach (var challenge in challenges)
                    {
//                        challenge.Patron = patron;
                        result.Add(challenge.ToChallengeDTO());
                    }
                }
            }

            MyResponder.RespondJson(context, result);
        }

        [RESTRoute(Method = HttpMethod.GET, PathInfo = @"^/Get/Patron/")]
        public void GetPatronForPerson(HttpListenerContext context)
        {
            string[] parameters = context.Request.RawUrl.Replace("/Get/Patron/", "").Split('/');

            int personId = int.Parse(parameters[0]);
            string token = parameters[1];


            var session = SessionManager.GetSession(token);

            PatronDTO result = null;

            if (session.user.People.Any(p => p.Id == personId && p.ConnectionType == ConnectionType.PersonToOwner))
            {
                var unit = new UnitOfWork(session.context);
                var patron = unit.Patrons.Find(p => p.Person.Id == personId).FirstOrDefault();

                result = patron != null ? patron.ToPatronDTO() : null;
            }

            MyResponder.RespondJson(context, result);
        }
    }
}
