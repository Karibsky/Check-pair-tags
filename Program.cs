using System;

namespace Brackets
{
    public class Program
    {
        static void Main(string[] args)
        {
            //DataSourceManager fileManager = new TxtFileSourceManager();
            DataSourceManager fileManager = new DbSourceManager();

            var inputText = fileManager.ReadData();

            var isCorrect = CheckExpression.IsCorrect(inputText);

            fileManager.WriteResult(isCorrect);

            Console.WriteLine("Input text: {0} Result: {1}", inputText, isCorrect);
        }
    }
}

