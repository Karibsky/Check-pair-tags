using System;

namespace TestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkWithFiles workWithFiles = new WorkWithFiles();
            workWithFiles.ReadFromSource(Configuration.GetInputPath());
            Console.ReadKey();
        }
    }
}

