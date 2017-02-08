using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Kaspersky
{
    class FirstCase
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Пример создания 10 потоков Push, паралельно запуская 10 потом Pop с случайной задержкой 0.001-0.01сек");
            Console.WriteLine(new string('-', 40));
            TestClass test = new TestClass();
            test.Test();
        }
    }
}
