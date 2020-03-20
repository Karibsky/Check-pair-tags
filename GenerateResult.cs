using System;

namespace TestTask
{
    class GenerateResult : IResult
    {
        public void PrintResult(string expression)
        {
            var result = string.Format("Expression: \n{0} \nResult: {1}", expression, CheckExpression.IsCorrect(expression));
            Console.WriteLine(result);
            WorkWithFiles workWithFiles = new WorkWithFiles();
            workWithFiles.WriteToSource(result);
        }
    }
}
