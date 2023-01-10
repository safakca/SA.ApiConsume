using System.ComponentModel.DataAnnotations;

namespace Frontend.Models;
public class UserLoginModel
{
    [Required(ErrorMessage ="Username required")]
    public string Username { get; set; } = null!;

    [Required(ErrorMessage ="Password required")]
    public string Password { get; set; } = null!;
}
