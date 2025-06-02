using JobAggregator.Core.Entities;
using JobAggregator.Core.Interfaces.Repositories;
using JobAggregator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace JobAggregator.Infrastructure.Repositories;

public class RoleRepository(AppDbContext context)
    : RepositoryBase<Role>(context), IRoleRepository
{
    public async Task<int> GetIdByNameAsync(string name)
    {
        var role = await context.Roles.FirstOrDefaultAsync(x => x.Name == name);
        if (role == null)
        {
            return -1;
        }
        return role.Id;
    }
}
