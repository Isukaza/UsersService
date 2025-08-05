using System.ComponentModel.DataAnnotations;

namespace UsersService.Models.Requests;

public class SubscriptionCreate
{
    [Required(ErrorMessage = "Type is required")]
    [MaxLength(50, ErrorMessage = "Type cannot exceed 50 characters")]
    public string Type { get; set; }

    [Required(ErrorMessage = "StartDate is required")]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "EndDate is required")]
    public DateTime EndDate { get; set; }
}