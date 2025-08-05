using DAL.Models;
using DAL.Repositories.Interfaces;
using UsersService.Models;

namespace UsersService.Managers;

public class UserManager(IUserRepository repo) : IUserManager
{
    public async Task<IEnumerable<UserInfo>> GetAllAsync()
    {
        var users = await repo.GetAllAsync();
        return users.Select(ToUserInfo);
    }

    public async Task<UserInfo?> GetByIdAsync(int id)
    {
        var user = await repo.GetByIdAsync(id);
        return user == null
            ? null
            : ToUserInfo(user);
    }

    public async Task<UserInfo> CreateAsync(UserCreate userCreate)
    {
        var user = new User
        {
            Name = userCreate.Name,
            Email = userCreate.Email,
            SubscriptionId = userCreate.SubscriptionId
        };

        var created = await repo.CreateAsync(user);
        return ToUserInfo(created);
    }

    public async Task<UserInfo> UpdateAsync(UserUpdate userUpdate)
    {
        var existing = await repo.GetByIdAsync(userUpdate.Id);
        if (existing == null)
            return null;

        if (!string.IsNullOrWhiteSpace(userUpdate.Name))
            existing.Name = userUpdate.Name;

        if (!string.IsNullOrWhiteSpace(userUpdate.Email))
            existing.Email = userUpdate.Email;

        if (userUpdate.SubscriptionId.HasValue)
            existing.SubscriptionId = userUpdate.SubscriptionId.Value;

        var updated = await repo.UpdateAsync(existing);
        return ToUserInfo(updated);
    }

    public async Task<bool> DeleteAsync(int id) =>
        await repo.DeleteAsync(id);

    private static UserInfo ToUserInfo(User u) =>
        new()
        {
            Id = u.Id,
            Name = u.Name,
            Email = u.Email,
            SubscriptionType = u.Subscription?.Type
        };
}