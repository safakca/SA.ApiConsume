using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Frontend.Models;
public class UpdateProductModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Name required")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Stock required")]
    public int Stock { get; set; }
    [Required(ErrorMessage = "Price required")]
    public decimal Price { get; set; }
    [Required(ErrorMessage = "Category selected required")]
    public int CategoryId { get; set; }
    public SelectList? Categories { get; set; }
}
