namespace WebClient.Interface
{
    public interface IEntryInterface
    {
        Task<T> GetData<T>();
    }
}
