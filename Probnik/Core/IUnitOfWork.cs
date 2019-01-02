using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Probnik.Core.Repositories;

namespace Probnik.Core
{
    public interface IUnitOfWork: IDisposable
    {
        IUserRepository Users { get; }
        void Complete();
    }
}
