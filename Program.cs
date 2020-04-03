using System;

namespace TestTask
{
    public class Program
    {
        static void Main(string[] args)
        {
            //FileManager fileManager = new TxtFileManager();
            DataSourceManager fileManager = new DbSourceManager();

            var inputText = fileManager.ReadData();

            var isCorrect = CheckExpression.IsCorrect(inputText);

            fileManager.WriteResult(isCorrect);

            Console.WriteLine("Input text: {0} Result: {1}", inputText, isCorrect);
        }
    }
}

