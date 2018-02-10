namespace SolidOod.Module5_I.Interfaces
{
    public interface IStoreLogger
    {
        void DidNotFind(int id);

        void Reading(int id);

        void Returning(int id);
    }
}