using ePizzaHub.Repositories.Contracts;
using ePizzHub.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;


namespace ePizzaHub.Repositories.Concrete
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ePizzaHub_ScholarHatContext dbContext) : base(dbContext)
        {
        }
        public async Task<User> FindByUserNameAsync(string userName)
        {
            return await _dbContext
                          .Users
                          .Include(x => x.Roles)
                          .FirstOrDefaultAsync(x => x.Email == userName);
        }
    }
}
