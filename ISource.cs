namespace Brackets
{
    public interface ISource
    {
        string ReadData();

        void WriteResult(bool result);
    }
}
