using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartClac.Class;
using SmartClac.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClac.Test
{
    public abstract class BaseTest
    {
      protected readonly ICalculation _Icalculation;
        public BaseTest(ClsClaculation _calculation)
        {
            _Icalculation = _calculation);
        }
    }
}
