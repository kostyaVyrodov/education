using System.IO;

namespace SolidOod.Module6_D.Interfaces
{
    public interface IFileLocator
    {
        FileInfo GetFileInfo(int id);
    }
}
