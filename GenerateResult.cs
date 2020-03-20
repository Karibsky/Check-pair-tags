using System;

namespace TestTask
{
    class GenerateResult
    {
        public static void PrintResult(string expression)
        {
            var result = string.Format("Expression: {0} Result: {1}", expression, CheckExpression.IsCorrect(expression));
            Console.WriteLine(result);
            WorkWithFiles.WriteToFile(result);
        }
    }
}
