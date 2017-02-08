using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Kaspersky
{
    class TestClass
    {
        Queue<int> queue;

        public void Test()
        {
            queue = new Queue<int>(1);
            Thread thread = new Thread(new ParameterizedThreadStart(doWork));
            thread.Start(queue);
            Console.ReadLine();
        }

        public void doWork(object obj)
        {
            for (int i = 0; i < 20; i++)
            {
                Thread thread = new Thread(new ParameterizedThreadStart(popStart));
                thread.Start(queue);
                Thread thread2 = new Thread(new ParameterizedThreadStart(pushStart));
                thread2.Start(queue);
            }
        }

        public void popStart(object queue)
        {
            Random rand = new Random();
            Thread.Sleep(rand.Next(10, 100));
            ((Queue<int>)queue).Pop();
        }

        public void pushStart(object queue)
        {
            Random rand = new Random();
            ((Queue<int>)queue).Push(rand.Next(1, 100));
        }
    }
}
