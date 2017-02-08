using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasperskySecondCase
{
    class Program
    {
        static void Main(string[] args)
        {
            Test(new AlgorithmLogic(10));
            Test(new AlgorithmLogic(5));
            Test(new AlgorithmLogic(15));
            Test(new AlgorithmLogic(2000000));
            Console.ReadLine();

        }

        private static void Test(AlgorithmLogic collection)
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Расчет");
            Console.WriteLine(new string('-', 40));
            AlgorithmLogic calculator = collection;
            calculator.GenerateAndPrint();
            calculator.Calculate();
        }
    }
}
