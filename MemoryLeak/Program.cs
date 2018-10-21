using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MemoryLeak
{
    class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var limit = 9400;
                while (true)
                {
                    var thread = new Thread(() => IncreaseMemory(limit));
                    thread.Start();

                    Task.Run(() => IncreaseMemoryString()).Wait();
                }
            }
            catch (Exception)
            {
                // swallow exception
            }

        }

        private static void IncreaseMemory(long limity)
        {
            var limit = limity;

            var list = new List<byte[]>();
            try
            {
                while (true)
                {
                    list.Add(new byte[limit]); // Change the size here.                  
                    //Thread.Sleep(1000); // Change the wait time here.
                }
            }
            catch (Exception ex)
            {
                // do nothing
            }
        }

        private static void IncreaseMemoryString()
        {
            string init = string.Empty;
            int i = 0;
            while(i < 100_000)
            {
                init = init + "prova ";
                i++;
            }
        }
    }
}
