﻿using Grapevine;
using Grapevine.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Probnik.Presistence;
using Probnik.Core.DTO;

namespace Probnik.REST.Controllers
{
    public sealed class TeamsController : RESTResource
    {

        [RESTRoute(Method = HttpMethod.GET, PathInfo = @"^/Get/Teams/")]
        public void GetTeamsByMethodology(HttpListenerContext context)
        {
            string[] parameters = context.Request.RawUrl.Replace("/Get/Teams/", "").Split('/');

            string token = parameters[0];
            int methodologyId = int.Parse(parameters[1]);

            var session = SessionManager.GetSession(token);

            var unit = new UnitOfWork(session.context);

            var teams = unit.Teams.FindTeamsWithMembersAndPatrons(t => t.Methodologies.Any(m => m.Id == methodologyId)).ToList();

            var result = new List<TeamDTO>();

            foreach (var team in teams)
            {
                result.Add(team.ToDTO());
            }

            MyResponder.RespondJson(context, result);
        }

        [RESTRoute(Method = HttpMethod.GET, PathInfo = @"^/Get/Methodologies")]
        public void GetAllMethodologies(HttpListenerContext context)
        {
            string token = context.Request.RawUrl.Replace("/Get/Methodologies/", "");
            var session = SessionManager.GetSession(token);

            var methodologies = session.context.Methodologies.ToList();

            MyResponder.RespondJson(context, methodologies);
        }

        [RESTRoute(Method = HttpMethod.GET, PathInfo = @"^/Get/UserTeams/")]
        public void GetUserTeams(HttpListenerContext context)
        {
            string token = context.Request.RawUrl.Replace("/Get/UserTeams/", "");

            var session = SessionManager.GetSession(token);

            var unit = new UnitOfWork(session.context);

            var personId = session.user.People.FirstOrDefault(p => p.ConnectionType == ConnectionType.PersonToOwner).Id;

            var person = unit.People.GetPersonWithTeams(personId.Value);
            var teams = person.Teams.ToList();

            var result = new List<TeamDTO>();

            foreach (var team in teams)
            {
                result.Add(team.ToDTO());
            }

            MyResponder.RespondJson(context, result);
        }


        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/Join/Team/")]
        public void JoinTeam(HttpListenerContext context)
        {
            string[] parameters = context.Request.RawUrl.Replace("/Join/Team/", "").Split('/');
            int teamId = int.Parse(parameters[0]);
            string token = parameters[1];


            var session = SessionManager.GetSession(token);

            var personDTO = RESTHelper.GetObject<PersonDTO>(context);

            if (session.user.People.Any(p => p.PersonId == personDTO.Id))
            {
                UnitOfWork unit = new UnitOfWork(session.context);

                var team = unit.Teams.GetTeamWithMembers(teamId);
                var person = unit.People.Get(personDTO.Id.Value);

                if (team != null && !team.Members.Any(m => m.Id == person.Id))
                {
                    team.Members.Add(person);
                    unit.Complete();
                }

                

                MyResponder.RespondJson(context, team.ToDTO());
            }
        }

    }
}
