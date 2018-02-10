using SolidOod.Module1;

namespace SolidOod.Module5_I.Interfaces
{
    public interface IStore
    {

        Maybe<string> ReadAllText(int id);

        void Save(int id, string message);
    }
}