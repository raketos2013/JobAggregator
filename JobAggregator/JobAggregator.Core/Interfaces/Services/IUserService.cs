using JobAggregator.Core.Entities;

namespace JobAggregator.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<User> CreateAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<bool> DeleteAsync(int id);
        Task<List<User>> GetAllAsync();
        Task<User> GetAsync(int id);
    }
}
