using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering; 

namespace Frontend.Models;

//TODO: Hata yonetimi olustur solid'e uyan
public class CreateProductModel
{
	[Required(ErrorMessage ="Name required")]
	public string? Name { get; set; }

	[Required(ErrorMessage ="Stock required")]
	public int Stock { get; set; }
	[Required(ErrorMessage ="Price required")]
	public decimal Price { get; set; }
	[Required(ErrorMessage ="Category selected required")]
	public int CategoryId { get; set; }
	public SelectList? Categories { get; set; }
}

