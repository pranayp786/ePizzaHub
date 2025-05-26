using ePizzaHub.Repositories.Contracts;
using ePizzHub.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Repositories.Concrete
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(ePizzaHub_ScholarHatContext dbContext) : base(dbContext)
        {
        }
    }
}
