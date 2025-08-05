using UsersService.Models.Requests;
using UsersService.Models.Responses;

namespace UsersService.Managers;

public interface ISubscriptionManager
{
    Task<IEnumerable<SubscriptionInfo>> GetAllAsync();
    Task<SubscriptionInfo> GetByIdAsync(int id);
    Task<SubscriptionInfo> CreateAsync(SubscriptionCreate createDto);
    Task<SubscriptionInfo> UpdateAsync(SubscriptionUpdate updateDto);
    Task<bool> DeleteAsync(int id);
}