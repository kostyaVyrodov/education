using System.IO;

namespace SolidOod.Module5_I.Interfaces
{
    public interface IFileLocator
    {
        FileInfo GetFileInfo(int id);
    }
}
