using DAL.Models;
using DAL.Repositories.Interfaces;
using UsersService.Models.Requests;
using UsersService.Models.Responses;

namespace UsersService.Managers;

public class SubscriptionManager(ISubscriptionRepository repo) : ISubscriptionManager
{
    public async Task<IEnumerable<SubscriptionInfo>> GetAllAsync()
    {
        var subs = await repo.GetAllAsync();
        return subs.Select(ToSubscriptionInfo);
    }

    public async Task<SubscriptionInfo?> GetByIdAsync(int id)
    {
        var sub = await repo.GetByIdAsync(id);
        return sub == null ? null : ToSubscriptionInfo(sub);
    }

    public async Task<SubscriptionInfo> CreateAsync(SubscriptionCreate createDto)
    {
        var subscription = new Subscription
        {
            Type = Enum.Parse<DAL.Models.Enums.SubscriptionType>(createDto.Type, true),
            StartDate = createDto.StartDate,
            EndDate = createDto.EndDate
        };
        var created = await repo.CreateAsync(subscription);
        return ToSubscriptionInfo(created);
    }

    public async Task<SubscriptionInfo?> UpdateAsync(SubscriptionUpdate updateDto)
    {
        var existing = await repo.GetByIdAsync(updateDto.Id);
        if (existing == null) return null;

        if (!string.IsNullOrWhiteSpace(updateDto.Type))
            existing.Type = Enum.Parse<DAL.Models.Enums.SubscriptionType>(updateDto.Type, true);

        if (updateDto.StartDate.HasValue)
            existing.StartDate = updateDto.StartDate.Value;

        if (updateDto.EndDate.HasValue)
            existing.EndDate = updateDto.EndDate.Value;

        var updated = await repo.UpdateAsync(existing);
        return ToSubscriptionInfo(updated);
    }

    public async Task<bool> DeleteAsync(int id) => await repo.DeleteAsync(id);

    private static SubscriptionInfo ToSubscriptionInfo(Subscription s) =>
        new()
        {
            Id = s.Id,
            Type = s.Type.ToString(),
            StartDate = s.StartDate,
            EndDate = s.EndDate
        };
}