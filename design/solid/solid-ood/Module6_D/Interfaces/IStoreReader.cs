using SolidOod.Module1;

namespace SolidOod.Module6_D.Interfaces
{
    public interface IStoreReader
    {
        Maybe<string> Read(int id);
    }
}
