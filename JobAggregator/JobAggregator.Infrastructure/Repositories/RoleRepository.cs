using JobAggregator.Core.Entities;
using JobAggregator.Core.Interfaces.Repositories;
using JobAggregator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace JobAggregator.Infrastructure.Repositories
{
    public class RoleRepository(AppDbContext context)
        : RepositoryBase<Role>(context), IRoleRepository
    {
        public async Task<int> GetIdByNameAsync(string name)
        {
            Role role = await context.Roles.FirstOrDefaultAsync(x => x.Name == name);
            return role.Id;
        }
    }
}
