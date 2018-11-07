﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probnik.Core.Repositories
{
    interface IChallangeRepository : IRepository<Challange>
    {
        ICollection<Challange> GetPersonChallanges(int personId);
        ICollection<Challange> GetPatronChallanges(int patronId);
        ICollection<Challange> GetChallangesByTask(int taskId);
        ICollection<Challange> GetChallangeForPersonWithTasksInState(int personId, byte taskState);

    }
}