using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidOod.Module5.Interfaces
{
    public interface IFileLocator
    {
        FileInfo GetFileInfo(int id);
    }
}
