namespace UsersService.Models.Responses;

public class SubscriptionInfo
{
    public int Id { get; set; }
    public string Type { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}