using JobAggregator.Core.Entities;
using JobAggregator.Core.Interfaces.Repositories;
using JobAggregator.Core.Interfaces.Services;

namespace JobAggregator.Core.Services;

public class RoleService(IUnitOfWork unitOfWork) : IRoleService
{
    public async Task<Role> CreateAsync(Role role)
    {
        var createdRole = await unitOfWork.RoleRepository.CreateAsync(role);
        // TODO: поменять exception на свой
        return await unitOfWork.SaveAsync() > 0 ? createdRole : throw new Exception();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var deleted = await unitOfWork.RoleRepository.DeleteAsync(id);
        return deleted && await unitOfWork.SaveAsync() > 0;
    }

    public async Task<List<Role>> GetAllAsync()
    {
        return await unitOfWork.RoleRepository.GetAllAsync();
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
        // TODO: поменять exception на свой
        return await unitOfWork.SaveAsync() > 0 ? updatedRole : throw new Exception();
    }
}
