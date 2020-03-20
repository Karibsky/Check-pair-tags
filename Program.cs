using System;

namespace TestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkWithFiles.OpenFile(Configuration.GetInputPath());
            Console.ReadKey();
        }
    }
}

