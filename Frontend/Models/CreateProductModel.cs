using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Frontend.Models;

public class CreateProductModel
{
	public string? Name { get; set; }
	public int Stock { get; set; }
	public decimal Price { get; set; }
	public int CategoryId { get; set; }
	public SelectList? Categories { get; set; }
}

