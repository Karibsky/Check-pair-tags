using System;

namespace TestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            ISource source = new FileSource();
            IResultGenerator generator = new ResultGenerator();

            var inputText = source.ReadFromSource(Configuration.GetInputPath());

            var isCorrect = CheckExpression.IsCorrect(inputText);
            var result = generator.GetResult(inputText, isCorrect);

            source.WriteToDestination(Configuration.GetOutputPath(), result);

            Console.WriteLine(result);
        }
    }
}

