using SmartClac.Class;
using System;

namespace SmartClac
{
    class Program
    {
        static void Main(string[] args)
        {         
            do
            {
                Console.Write("Insert Mathmatical Formula: ");     
                
                Console.Write("= "+Claculation.Claculate(Console.ReadLine())
                    + "\n Press n/N To Close any key To Continuous: ");                              
            }
            while (Console.ReadLine().ToLower() != "n");
        }
    }
}
