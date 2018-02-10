using System.IO;

namespace SolidOod.Module6.Interfaces
{
    public interface IFileLocator
    {
        FileInfo GetFileInfo(int id);
    }
}
