using System.IO;

namespace TestTask
{
    public interface ISource
    {
        string ReadFromSource(string path);

        void WriteToDestination(string path, string text);
    }
}
