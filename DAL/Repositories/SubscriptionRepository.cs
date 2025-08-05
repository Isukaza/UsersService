using DAL.Models;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class SubscriptionRepository(UserDbContext context) : ISubscriptionRepository
{
    public async Task<Subscription> GetByIdAsync(int id) =>
        await context.Subscriptions.FindAsync(id);

    public async Task<IEnumerable<Subscription>> GetAllAsync() =>
        await context.Subscriptions.ToListAsync();

    public async Task<Subscription> CreateAsync(Subscription subscription)
    {
        await context.Subscriptions.AddAsync(subscription);
        await context.SaveChangesAsync();
        return subscription;
    }

    public async Task<Subscription> UpdateAsync(Subscription subscription)
    {
        context.Subscriptions.Update(subscription);
        await context.SaveChangesAsync();
        return subscription;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await context.Subscriptions.FindAsync(id);
        if (entity == null)
            return false;

        context.Subscriptions.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }
}