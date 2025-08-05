using System.ComponentModel.DataAnnotations;

namespace UsersService.Models.Requests;

public class SubscriptionUpdate
{
    [Required(ErrorMessage = "Id is required")]
    public int Id { get; set; }

    public string Type { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}