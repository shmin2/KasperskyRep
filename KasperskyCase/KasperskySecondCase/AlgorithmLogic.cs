using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasperskySecondCase
{
    class AlgorithmLogic
    {
        Random rand = new Random();
        int target;
        List<int> coll;
        int size;

        public AlgorithmLogic(int collectionSize)
        {
            size = collectionSize;
            target = rand.Next(1, 10);
            coll = new List<int>();
        }
        public void GenerateAndPrint()
        {
            for (int i = 0; i < size; i++)
            {
                coll.Add(rand.Next(-10, 10));
            }

            foreach (var item in coll)
            {
                Console.Write(item);
                Console.Write(" ");
            }
            Console.WriteLine(" ---> X={0}", target);
        }

        public void Calculate()
        {
            var IcollSorted = coll.OrderBy(i => i);
            var collSorted = IcollSorted.ToArray();
            foreach (var item in collSorted)
            {
                Console.Write(item);
                Console.Write(" ");
            }
            Console.WriteLine();
            int head = 0;
            int tail = collSorted.Length - 1;
            int count = 0;

            while (head != tail)
            {
                if (collSorted[head] + collSorted[tail] == target)
                {
                    count++;
                    Console.WriteLine("{0}:{1}", collSorted[head], collSorted[tail]);
                    tail--;
                    continue;
                }
                if (collSorted[head] + collSorted[tail] > target)
                    tail--;
                if (collSorted[head] + collSorted[tail] < target)
                    head++;
            }
            Console.WriteLine("Combine count: {0}", count);
        }
    }
}
