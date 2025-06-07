namespace ePizzaHub.Core.Contracts
{
    public interface ICartService
    {
        Task<int> GetCartItemCountAsync(Guid cartId);
    }
}
