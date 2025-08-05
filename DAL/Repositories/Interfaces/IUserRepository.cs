using DAL.Models;
using DAL.Models.Enums;

namespace DAL.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User> GetByIdAsync(int id);
    Task<IEnumerable<User>> GetAllAsync();
    Task<IEnumerable<User>> GetUsersBySubscriptionTypeAsync(SubscriptionType type);
    Task<User> CreateAsync(User user);
    Task<User> UpdateAsync(User user);
    Task<bool> DeleteAsync(int id);
}