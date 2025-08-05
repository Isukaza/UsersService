using DAL.Models;

namespace DAL.Repositories.Interfaces;

public interface ISubscriptionRepository
{
    Task<Subscription> GetByIdAsync(int id);
    Task<IEnumerable<Subscription>> GetAllAsync();
    Task<Subscription> CreateAsync(Subscription subscription);
    Task<Subscription> UpdateAsync(Subscription subscription);
    Task<bool> DeleteAsync(int id);
}