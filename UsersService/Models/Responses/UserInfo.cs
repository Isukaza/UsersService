using DAL.Models.Enums;

namespace UsersService.Models.Responses;

public class UserInfo
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public SubscriptionType? SubscriptionType { get; set; }
}