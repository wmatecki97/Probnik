﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probnik
{
    public class Methodology
    {
        public byte? Id { get; set; }
        public string Name { get; set; }

        public Methodology()
        {
        }
        public Methodology(string name)
        {
            Name = name;
        }
    }
}
