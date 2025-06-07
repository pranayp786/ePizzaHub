using ePizzaHub.Repositories.Contracts;
using ePizzHub.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Repositories.Concrete
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        public CartRepository(ePizzaHub_ScholarHatContext dbContext) : base(dbContext)
        {
        }

        public async Task<int> GetCartItemQuantityAsync(Guid guid)
        {
            int itemCount = await _dbContext.CartItems.Where(x => x.CartId == guid).CountAsync();
            return itemCount;
        }
    }
}
