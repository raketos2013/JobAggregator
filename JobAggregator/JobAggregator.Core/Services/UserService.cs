using JobAggregator.Core.Entities;
using JobAggregator.Core.Enum;
using JobAggregator.Core.Exceptions;
using JobAggregator.Core.Interfaces.Repositories;
using JobAggregator.Core.Interfaces.Services;

namespace JobAggregator.Core.Services;

public class UserService(IUnitOfWork unitOfWork,
                            IRoleService roleService) : IUserService
{
    public async Task<User> CreateAsync(User user)
    {
        user.RoleId = await roleService.GetIdByNameAsync(UserRole.USER.ToString());
        user.Status = UserStatus.Active;
        var createdUser = await unitOfWork.UserRepository.CreateAsync(user);
        return await unitOfWork.SaveAsync() > 0 ? createdUser : throw new DomainException();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var deleted = await unitOfWork.UserRepository.DeleteAsync(id);
        return deleted && await unitOfWork.SaveAsync() > 0;
    }

    public async Task<User?> GetAsync(int id)
    {
        return await unitOfWork.UserRepository.GetAsync(id);
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await unitOfWork.UserRepository.GetAllAsync();
    }

    public async Task<User> UpdateAsync(User user)
    {
        var updatedUser = unitOfWork.UserRepository.Update(user);
        return await unitOfWork.SaveAsync() > 0 ? updatedUser : throw new DomainException();
    }
}
