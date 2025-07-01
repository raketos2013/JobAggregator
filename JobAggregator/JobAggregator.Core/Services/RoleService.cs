using JobAggregator.Core.Entities;
using JobAggregator.Core.Exceptions;
using JobAggregator.Core.Extensions;
using JobAggregator.Core.Interfaces.Repositories;
using JobAggregator.Core.Interfaces.Services;
using JobAggregator.Core.Queries;

namespace JobAggregator.Core.Services;

public class RoleService(IUnitOfWork unitOfWork) : IRoleService
{
    public async Task<Role> CreateAsync(Role role)
    {
        var createdRole = await unitOfWork.RoleRepository.CreateAsync(role);
        return await unitOfWork.SaveAsync() > 0 ? createdRole : throw new DomainException("Failed to create role.");
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var deleted = await unitOfWork.RoleRepository.DeleteAsync(id);
        return deleted && await unitOfWork.SaveAsync() > 0;
    }

    public async Task<PagedList<Role>> GetAllAsync(Query query)
    {
        return await unitOfWork.RoleRepository.GetAllAsync(query);
    }

    public async Task<Role?> GetAsync(int id)
    {
        return await unitOfWork.RoleRepository.GetAsync(id);
    }

    public async Task<int> GetIdByNameAsync(string name)
    {
        return await unitOfWork.RoleRepository.GetIdByNameAsync(name);
    }

    public async Task<Role> UpdateAsync(Role role)
    {
        var updatedRole = unitOfWork.RoleRepository.Update(role);
        return await unitOfWork.SaveAsync() > 0 ? updatedRole : throw new DomainException("Failed to update role.");
    }
}
