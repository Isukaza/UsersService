using DAL.Models;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class UserRepository(UserDbContext context) : IUserRepository
{
    public async Task<User?> GetByIdAsync(int id) =>
        await context.Users
            .Include(u => u.Subscription)
            .FirstOrDefaultAsync(u => u.Id == id);


    public async Task<IEnumerable<User>> GetAllAsync() =>
        await context.Users
            .Include(u => u.Subscription)
            .ToListAsync();

    public async Task<Subscription?> GetSubscriptionAsync(int subscriptionId) =>
        await context.Subscriptions.FirstOrDefaultAsync(s => s.Id == subscriptionId);
}