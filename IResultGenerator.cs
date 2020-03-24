namespace TestTask
{
    public interface IResultGenerator
    {
        string GetResult(string expression, bool isCorrect);
    }
}
