using System;
using System.IO;
using SolidOod.Module6_D;
using SolidOod.Module6_D.Interfaces;

namespace SolidOod
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileStore = new FileStore(new DirectoryInfo(Environment.CurrentDirectory));
            var cache = new StoreCache(fileStore, fileStore);
            var log = new StoreLogger(cache, cache);
            var msgStor = new MessageStore(log, log, fileStore);
        }
    }
}
