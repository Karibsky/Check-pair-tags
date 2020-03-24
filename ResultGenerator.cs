namespace TestTask
{
    public class ResultGenerator : IResultGenerator
    {
        public string GetResult(string expression, bool isCorrect)
        {
            return string.Format("Expression: \n{0} \nResult: {1}", expression, isCorrect);
        }
    }
}
