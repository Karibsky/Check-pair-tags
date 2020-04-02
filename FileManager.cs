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
   
        public void WriteToDestination(bool result, string path = null)
        {
            ISource source = CreateStorage();
            source.WriteToDestination(result, path);
        }
    }
}
