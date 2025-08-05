using DAL.Repositories.Interfaces;
using UsersService.Models;

namespace UsersService.Managers
{
    public class UserManager(IUserRepository repo) : IUserManager
    {
        public async Task<IEnumerable<UserInfo>> GetAllAsync()
        {
            var users = await repo.GetAllAsync();
            return users.Select(u => new UserInfo
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                SubscriptionType = u.Subscription?.Type
            });
        }

        public async Task<UserInfo> GetByIdAsync(int id)
        {
            var user = await repo.GetByIdAsync(id);
            if (user == null)
                return null;

            return new UserInfo
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                SubscriptionType = user.Subscription?.Type
            };
        }
    }
}