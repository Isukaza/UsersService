using System.ComponentModel.DataAnnotations;

namespace UsersService.Models;

public class UserUpdate
{
    [Required(ErrorMessage = "Id is required")]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int? SubscriptionId { get; set; }
}