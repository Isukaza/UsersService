using UsersService.Models;

namespace UsersService.Managers;

public interface IUserManager
{
    Task<IEnumerable<UserInfo>> GetAllAsync();
    Task<UserInfo?> GetByIdAsync(int id);
}