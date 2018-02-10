using System.IO;
using SolidOod.Module1;

namespace SolidOod.Module4_L
{
    public interface IStore
    {
        FileInfo GetFileInfo(int id);

        Maybe<string> ReadAllText(int id);

        void WriteAllText(int id, string message);
    }
}