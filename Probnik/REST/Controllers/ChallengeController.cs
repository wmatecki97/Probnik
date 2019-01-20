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

            var team = unit.Teams.Get(teamId);
            

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


//        [RESTRoute(Method = HttpMethod.GET, PathInfo = @"^/Get/TasksStates/")]
//        public void GetTasksStates(HttpListenerContext context)
//        {
//            string[] parameters = context.Request.RawUrl.Replace("/Get/TasksStates/", "").Split('/');
//            var token = parameters[0];
//            var session = SessionManager.GetSession(token);
//
////            var result = session.context.TaskStateses.ToList();
//
//            MyResponder.RespondJson(context, result);
//        }

        [RESTRoute(Method = HttpMethod.GET, PathInfo = @"^/Get/ChallengeFor/")]
        public void GetChallengeForPerson(HttpListenerContext context)
        {
            string[] parameters = context.Request.RawUrl.Replace("/Get/ChallengeFor/", "").Split('/');

            int challengeTypeId = int.Parse(parameters[0]);
            int personId = int.Parse(parameters[1]);
            string token = parameters[2];

            var session = SessionManager.GetSession(token);
            var result = new List<ChallengeDTO>();



            if (session.user.People.Any(p => p.Id == personId))
            {
                var unit = new UnitOfWork(session.context);
                var challenges = unit.Challanges.Find(c => c.Owner.Id == personId 
                                                   && c.Task.ChallangeTypeId == challengeTypeId).ToList();
                foreach (var challenge in challenges)
                {
                    result.Add(challenge.ToChallengeDTO());
                }
            }

            MyResponder.RespondJson(context, result);
        }

//        [RESTRoute(Method = HttpMethod.GET, PathInfo = @"^/Get/UserTeams/")]
//        public void GetUserTeams(HttpListenerContext context)
//        {
//            string token = context.Request.RawUrl.Replace("/Get/UserTeams/", "");
//
//            var session = SessionManager.GetSession(token);
//
//            var unit = new UnitOfWork(session.context);
//
//            var personId = session.user.People.FirstOrDefault(p => p.ConnectionType == ConnectionType.PersonToOwner).Id;
//
//            var person = unit.People.GetPersonWithTeams(personId.Value);
//            var teams = person.Teams.ToList();
//
//            var result = new List<TeamDTO>();
//
//            foreach (var team in teams)
//            {
//                result.Add(team.ToDTO());
//            }
//
//            MyResponder.RespondJson(context, result);
//        }


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
                SaveChanges(context, unit, personChallengesDTO);
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

            var result = unit.Challanges.Find(c =>
                personChallengesDTO.Any(pc => pc.Owner.Id == c.Owner.Id && pc.TaskId == c.TaskId)).ToList();

            var resultDTO = new List<ChallengeDTO>();
            foreach (var challange in result)
            {
                resultDTO.Add(challange.ToChallengeDTO());
            }

            return resultDTO;
        }

        private static void SaveChanges(HttpListenerContext context, UnitOfWork unit, List<ChallengeDTO> personChallengesDTO)
        {
            var challengesIds = personChallengesDTO.Select(pc => pc.Id);
            var challenges = unit.Challanges.Find(c => challengesIds.Any(id => id == c.Id)).ToList();


            foreach (var challenge in personChallengesDTO)
            {
                var toEdit = challenges.First(c => c.Id == challenge.Id);
                toEdit.Mission = challenge.Mission;
                toEdit.State = challenge.State;
                toEdit.Comment = challenge.Comment;
                if(challenge.Patron != null)
                    toEdit.PatronId = challenge.Patron.Id;
            }

            unit.Complete();

            
        }
    }
}
