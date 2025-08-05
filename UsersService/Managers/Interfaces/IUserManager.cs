using DAL.Models.Enums;
using UsersService.Models.Requests;
using UsersService.Models.Responses;

namespace UsersService.Managers.Interfaces;

public interface IUserManager
{
    Task<IEnumerable<UserInfo>> GetAllAsync();
    Task<UserInfo> GetByIdAsync(int id);
    Task<IEnumerable<UserInfo>> GetUsersBySubscriptionTypeAsync(SubscriptionType type);
    Task<UserInfo> CreateAsync(UserCreate userCreate);
    Task<UserInfo> UpdateAsync(UserUpdate userUpdate);
    Task<bool> DeleteAsync(int id);
}