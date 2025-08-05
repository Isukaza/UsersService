using Microsoft.EntityFrameworkCore;
using DAL.Models;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories;

public class UserRepository(UserDbContext context) : IUserRepository
{
    public async Task<User> GetByIdAsync(int id) =>
        await context.Users
            .Include(u => u.Subscription)
            .FirstOrDefaultAsync(u => u.Id == id);

    public async Task<IEnumerable<User>> GetAllAsync() =>
        await context.Users
            .Include(u => u.Subscription)
            .ToListAsync();

    public async Task<User> CreateAsync(User user)
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return user;
    }

    public async Task<User> UpdateAsync(User user)
    {
        context.Users.Update(user);
        await context.SaveChangesAsync();
        return user;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await context.Users.FindAsync(id);
        if (entity == null) return false;

        context.Users.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }
}