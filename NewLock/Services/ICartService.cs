namespace NewLock.Services
{
    public interface ICartService
    {
        Task<int> GetCartItemCountAsync();
    }
}