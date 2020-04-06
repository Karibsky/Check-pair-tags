namespace Brackets
{
    class DataSourceIoC<T> : DataSourceManager where T : ISource, new()
    {
        public override ISource CreateStorage()
        {
            return new T();
        }
    }
}
