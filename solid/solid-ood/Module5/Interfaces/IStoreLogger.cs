namespace SolidOod.Module5.Interfaces
{
    public interface IStoreLogger
    {
        void DidNotFind(int id);

        void Reading(int id);

        void Returning(int id);

        void Saved(int id, string message);

        void Saving(int id, string message);
    }
}