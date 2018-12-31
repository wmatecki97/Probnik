using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Probnik.REST
{
    class SessionManager
    {
        private static Semaphore sem;
        private static List<Session> sessions;
        public static List<string> usedTokens;

        static SessionManager()
        {
            sessions = new List<Session>();
            sem = new Semaphore(1,1);
            usedTokens = new List<string>();
        }

        public static void AddSession(Session session)
        {
            sem.WaitOne();
            if(GetSessionWithoutSemaphore(session.token) == null)
                sessions.Add(session);
            sem.Release();
        }


        public static Session GetSession(string token)
        {
            sem.WaitOne();
            var session = sessions.FirstOrDefault(s => s.token == token);
            sem.Release();

            return session;
        }

        private static Session GetSessionWithoutSemaphore(string token)
        {
            return sessions.FirstOrDefault(s => s.token == token);
        }

        public static void LogIn(string login, string password)
        {

        }
    }
}
