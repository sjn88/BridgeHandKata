namespace BridgeKata
{
    public interface IFileHandler
    {
        bool Exists(string fileName);
        string[] ReadAllLines(string fileName);
    }
}