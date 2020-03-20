namespace TestTask
{
    interface ISource
    {
        string ReadFromSource(string source);
        void WriteToDestination(string path, string result);
    }
}
