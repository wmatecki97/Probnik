using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probnik.Exceptions
{
    public class LoginInUseException : Exception
    {
        public override string Message => "Login is already in use";
    }
}
