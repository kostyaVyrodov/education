using System;
using System.IO;
using SolidOod.Module1;
using SolidOod.Module6_D.Interfaces;

namespace SolidOod.Module6_D
{
    public class MessageStore
    {
        private readonly IFileLocator fileLocator;
        private readonly IStoreReader reader;
        private readonly IStoreWriter writer;

        public MessageStore(IStoreReader reader, IStoreWriter writer, IFileLocator fileLocator)
        {
            if(fileLocator == null)
                throw new ArgumentNullException("fileLocator");
            if (reader == null)
                throw new ArgumentNullException("reader");
            if (writer == null)
                throw new ArgumentNullException("writer");

            this.fileLocator = fileLocator;
            this.reader = reader;
            this.writer = writer;
        }

        public void Save(int id, string message)
        {
            writer.Save(id, message);
        }

        public Maybe<string> Read(int id)
        {
            return reader.Read(id);
        }

        public FileInfo GetFileInfo(int id)
        {
            return this.fileLocator.GetFileInfo(id);
        }
    }
}
