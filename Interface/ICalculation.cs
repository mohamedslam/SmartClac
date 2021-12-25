using System;
using System.Collections.Generic;
using System.Text;

namespace SmartClac.Interface
{
  public  interface ICalculation
    {
        public  double Claculate(string expression);
        public List<string> GetTokens(string expression);
    }
}
