using System;

namespace TestTask
{
    public class Program
    {
        static void Main(string[] args)
        {
            //FileManager fileManager = new TxtFileManager();
            FileManager fileManager = new DbFileManager();

            var inputText = fileManager.ReadFromSource("1"); //Configuration.GetInputPath()

            var isCorrect = CheckExpression.IsCorrect(inputText);

            fileManager.WriteToDestination(isCorrect);

            Console.WriteLine("Input text: {0} Result: {1}", inputText, isCorrect);
        }
    }
}

