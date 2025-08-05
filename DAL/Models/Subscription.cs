using DAL.Models.Enums;

namespace DAL.Models;

public class Subscription
{
    public int Id { get; set; }
    public SubscriptionType Type { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public ICollection<User> Users { get; set; } = new List<User>();
}