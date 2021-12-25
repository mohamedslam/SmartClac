using SmartClac.Class;
using SmartClac.Interface;
using System;

namespace SmartClac
{
    class Program
    {
       public static void Main()
        {
            SmartCalsicCalculation();
        }
        private static  void SmartCalsicCalculation()
        {
            ICalculation _Icalculation = new ClsClaculation();
            do
            {
                Console.Write("Insert Mathmatical Formula: ");

                Console.Write("\b = " + _Icalculation.Claculate(Console.ReadLine())
                    + "\n Press n/N To Close any key To Calc New Operation: ");
            }
            while (Console.ReadLine().ToLower() != "n");
        }


    }
}
