using DAL.Models;

namespace DAL.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id);
    Task<IEnumerable<User>> GetAllAsync();
    Task<Subscription?> GetSubscriptionAsync(int subscriptionId);
}