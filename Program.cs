using System;
using System.IO;

namespace TestTask
{
    public class Program
    {
        static void Main(string[] args)
        {
            FileManager fileManager = new TxtFileManager();
            ISource source = fileManager.CreateStorage();

            IResultGenerator generator = new ResultGenerator();

            var inputText = fileManager.ReadFromSource(Configuration.GetInputPath());

            var isCorrect = CheckExpression.IsCorrect(inputText);
            var result = generator.GetResult(inputText, isCorrect);

            fileManager.WriteToDestination(Configuration.GetOutputPath(), result);

            Console.WriteLine(result);
        }
    }
}

