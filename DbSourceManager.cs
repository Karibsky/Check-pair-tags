using SqlDatabase;

namespace Brackets
{
    public class DbSourceManager : DataSourceManager
    {
        private class DbFileSource : ISource
        {
            public string ReadData()
            {
                var id = int.Parse(Configuration.GetDataSourceID());

                return BracketsDataService.GetTextByID(id);
            }

            public void WriteResult(bool result)
            {
                BracketsDataService.SaveResultToDatabase(result);
            }
        }

        public override ISource CreateStorage()
        {
            return new DbFileSource();
        }
    }
}
