using JobAggregator.Core.Entities;
using JobAggregator.Core.Enum;
using JobAggregator.Core.Interfaces.Repositories;
using JobAggregator.Core.Interfaces.Services;

namespace JobAggregator.Core.Services
{
    public class UserService(IUserRepository userRepository,
                                IRoleService roleService) : IUserService
    {
        public async Task<User> CreateAsync(User user)
        {
            user.RoleId = await roleService.GetIdByNameAsync(UserRole.USER.ToString());
            user.Status = UserStatus.Active;
            return await userRepository.CreateAsync(user);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deleted  = await userRepository.DeleteAsync(id);
            return deleted;
        }

        public async Task<User?> GetAsync(int id)
        {
            return await userRepository.GetAsync(id);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await userRepository.GetAllAsync();
        }

        public async Task<User> UpdateAsync(User user)
        {
            return await userRepository.UpdateAsync(user);
        }
    }
}
