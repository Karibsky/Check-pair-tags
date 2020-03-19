using System;
using System.Configuration;

namespace TestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            GenerateResult.OpenFile(Configuration.GetInputPath());
            Console.ReadKey();
        }
    }
}

