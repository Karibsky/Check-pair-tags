namespace TestTask
{
    public interface ISource
    {
        string ReadFromSource(string path);

        void WriteToDestination(bool text, string path);
    }
}
