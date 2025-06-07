using ePizzHub.Infrastructure.Models;

namespace ePizzaHub.Repositories.Contracts
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        Task<int> GetCartItemQuantityAsync(Guid guid);
    }
}
