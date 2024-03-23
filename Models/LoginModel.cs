using System.ComponentModel.DataAnnotations;

namespace SchedulerWeb.Models;

public class LoginModel
{
    [Required]
    public string Id { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
