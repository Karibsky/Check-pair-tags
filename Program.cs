using System;

namespace Brackets
{
    public class Program
    {
        static void Main(string[] args)
        {
            var dataSourceManager = new DataSourceIoC<DbSourceManager>();

            var inputText = dataSourceManager.ReadData();

            var isCorrect = CheckExpression.IsCorrect(inputText);

            dataSourceManager.WriteResult(isCorrect);

            Console.WriteLine("Input text: {0} Result: {1}", inputText, isCorrect);
        }
    }
}

