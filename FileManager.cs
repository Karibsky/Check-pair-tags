namespace TestTask
{
    public abstract class FileManager
    {
        public abstract ISource CreateStorage();

        public string ReadFromSource(string path)
        {
            ISource source = CreateStorage();
            var result = source.ReadFromSource(path);

            return result;
        }
   
        public void WriteToDestination(string path, string text)
        {
            ISource source = CreateStorage();
            source.WriteToDestination(path, text);
        }
    }
}
