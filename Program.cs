using SmartClac.Class;
using System;

namespace SmartClac
{
    class Program
    {
        static void Main(string[] args)
        { 
            bool _Resume = true;
            do
            {


                Console.WriteLine("Insert Formula To calculate it");
                var _UserFormula = Console.ReadLine();
                var Result = "";

                
                Result =Claculation.Claculate(_UserFormula).ToString();
                 

                Console.WriteLine("The Result Of  Formula : "+_UserFormula+" =  "+Result);
               

                Console.WriteLine("If You want Claculate Another Formula press y/Y");
                string val_Resume = Console.ReadLine();


                if (val_Resume == "Y" || val_Resume == "y")
                    _Resume = true;
                else
                    _Resume = false;

            }
            while (_Resume);


        }
    }
}
