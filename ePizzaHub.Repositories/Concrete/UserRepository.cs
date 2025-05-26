using ePizzaHub.Repositories.Contracts;
using ePizzHub.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Repositories.Concrete
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ePizzaHub_ScholarHatContext dbContext) : base(dbContext)
        {
        }
    }
}
