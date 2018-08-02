using System;
using System.Collections.Generic;
using System.Diagnostics; //need to using this namespace
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessStart
{
    class Program
    {
        static void Main(string[] args)
        {
            var process = new Process();

            var startInfo = new ProcessStartInfo();
            startInfo.FileName = "test"; // test is a C# console programe and its code 'Test.cs' is attached as comments
            startInfo.Arguments = "madoka homura"; // this process need 2 arguments
            process.StartInfo = startInfo;

            try
            {
                Console.WriteLine("Now start process test.exe with arguments madoka and homura.");
                process.Start();

                Console.WriteLine("Kill the process test.exe after 10 seconds.");
                for (int i = 10; i > 0; i--)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(1000);
                }

                Console.WriteLine("Now kill the process test.exe.");
                process.Kill();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("By.bunnyxt 2018-8-2");
        }
    }
}
