using UsersService.Models;
using UsersService.Models.Requests;
using UsersService.Models.Responses;

namespace UsersService.Managers;

public interface IUserManager
{
    Task<IEnumerable<UserInfo>> GetAllAsync();
    Task<UserInfo> GetByIdAsync(int id);
    Task<UserInfo> CreateAsync(UserCreate userCreate);
    Task<UserInfo> UpdateAsync(UserUpdate userUpdate);
    Task<bool> DeleteAsync(int id);
}