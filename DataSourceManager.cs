﻿namespace TestTask
{
    public abstract class DataSourceManager
    {
        public abstract ISource CreateStorage();

        public string ReadData()
        {
            ISource source = CreateStorage();
            var result = source.ReadData();

            return result;
        }
   
        public void WriteResult(bool result)
        {
            ISource source = CreateStorage();
            source.WriteResult(result);
        }
    }
}
