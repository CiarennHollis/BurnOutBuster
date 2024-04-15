﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnoutBuster.Utility
{
    interface ICreatureSubject
    {
        List<ICreatureObserver> observers { get; set; }
    }
}
