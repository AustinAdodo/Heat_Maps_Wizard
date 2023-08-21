using System;
using System.ComponentModel.DataAnnotations;

public class Product
{
    [Required]
    public int id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public decimal Price { get; set; }
    public string Description { get; set; }
    [Required]
    public DateTime CreatedDate { get; set;}
    public DateTime UpdatedDate { get; set;}
    public string ProductId { get; set; }
    public string ProductCategorty { get; set; }
}

