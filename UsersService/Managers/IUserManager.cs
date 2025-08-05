using UsersService.Models;

namespace UsersService.Managers;

public interface IUserManager
{
    Task<IEnumerable<UserInfo>> GetAllAsync();
    Task<UserInfo> GetByIdAsync(int id);
    Task<UserInfo> CreateAsync(UserCreate userCreate);
    Task<UserInfo> UpdateAsync(UserUpdate userUpdate);
    Task<bool> DeleteAsync(int id);
}