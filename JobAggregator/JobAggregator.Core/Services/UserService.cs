using JobAggregator.Core.Entities;
using JobAggregator.Core.Enum;
using JobAggregator.Core.Exceptions;
using JobAggregator.Core.Extensions;
using JobAggregator.Core.Interfaces.Repositories;
using JobAggregator.Core.Interfaces.Services;
using JobAggregator.Core.Queries;
using JobAggregator.Core.Utilities;
using System.Text;

namespace JobAggregator.Core.Services;

public class UserService(IUnitOfWork unitOfWork,
                            IRoleService roleService) : IUserService
{
    public async Task<User> CreateAsync(User user)
    {
        var existingUser = await GetByLoginAsync(user.Login);
        if (existingUser != null)
        {
            throw new DomainException("user with this login already exist.");
        }
        user.RoleId = await roleService.GetIdByNameAsync(UserRole.USER.ToString());
        user.Status = UserStatus.Active;

        var salt = HashedPassword.GenerateSalt();
        var hmac = HashedPassword.ComputeHMAC_SHA256(Encoding.UTF8.GetBytes(user.Password), salt);
        user.PasswordSalt = salt;
        user.Password = Convert.ToBase64String(hmac);

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

    public async Task<PagedList<User>> GetAllAsync(Query query)
    {
        return await unitOfWork.UserRepository.GetAllAsync(query);
    }

    public async Task<User> UpdateAsync(User user)
    {
        var updatedUser = unitOfWork.UserRepository.Update(user);
        return await unitOfWork.SaveAsync() > 0 ? updatedUser : throw new DomainException();
    }

    public async Task<User?> GetByLoginAsync(string login)
    {
        return await unitOfWork.UserRepository.GetByLoginAsync(login);
    }

    public async Task<bool> ValidateUserAsync(string login, string password)
    {
        var user = await GetByLoginAsync(login);
        if (user == null)
        {
            return false;
        }
        var hmac = HashedPassword.ComputeHMAC_SHA256(Encoding.UTF8.GetBytes(password), user.PasswordSalt);
        if (Convert.ToBase64String(hmac) == user.Password)
        {
            return true;
        }
        return false;
    }

    public async Task<bool> SaveVacancy(int userId, int vacancyId)
    {
        var user = await unitOfWork.UserRepository.GetVacanciesAsync(userId);
        if (user == null) 
            return false;
        var vacancy = await unitOfWork.VacancyRepository.GetAsync(vacancyId);
        if (vacancy == null)
            return false;
        if (user.Vacancies == null)
        {
            user.Vacancies = [vacancy];
        }
        else
        {
            user.Vacancies.Add(vacancy);
        }
        unitOfWork.UserRepository.Update(user);
        return await unitOfWork.SaveAsync() > 0;
    }

    public async Task<bool> DeleteVacancy(int userId, int vacancyId)
    {
        var user = await unitOfWork.UserRepository.GetVacanciesAsync(userId);
        if (user == null)
            return false;
        var vacancy = await unitOfWork.VacancyRepository.GetAsync(vacancyId);
        if (vacancy == null)
            return false;
        user.Vacancies.Remove(vacancy);
        unitOfWork.UserRepository.Update(user);
        return await unitOfWork.SaveAsync() > 0;
    }

    public async Task<List<Vacancy>> GetSavedVacancyAsync(int userId)
    {
        var user = await unitOfWork.UserRepository.GetVacanciesAsync(userId);
        return user.Vacancies;
    }

    public async Task<List<Resume>> GetUserResumesAsync(int userId)
    {
        return await unitOfWork.ResumeRepository.GetResumesByUserIdAsync(userId);
    }
}
