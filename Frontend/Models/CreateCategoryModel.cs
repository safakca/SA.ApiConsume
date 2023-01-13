using System.ComponentModel.DataAnnotations;

namespace Frontend.Models;
public class CreateCategoryModel
{
    [Required(ErrorMessage = "Category name is required ! ")]
    public string Defination { get; set; } = null!;
}
