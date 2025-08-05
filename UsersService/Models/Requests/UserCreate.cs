using System.ComponentModel.DataAnnotations;

namespace UsersService.Models.Requests;

public class UserCreate
{
    [Required(ErrorMessage = "Name is required")]
    [MaxLength(200, ErrorMessage = "Name cannot exceed 200 characters")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Email is not valid")]
    [MaxLength(200, ErrorMessage = "Email cannot exceed 200 characters")]
    public string Email { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "SubscriptionId must be greater than 0")]
    public int SubscriptionId { get; set; }
}