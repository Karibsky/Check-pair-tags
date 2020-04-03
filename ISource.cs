namespace TestTask
{
    public interface ISource
    {
        string ReadData();

        void WriteResult(bool result);
    }
}
