#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace CodePink.Models;
using System.ComponentModel.DataAnnotations.Schema;

public class Product
{
    [Key]
    public int ProductId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Category { get; set; }

    [Required]
    public double Price { get; set; }

    [Required]
    public string Img1 { get; set; }
    public string Img2 { get; set; }
    public string Img3 { get; set; }
    public string Img4 { get; set; }

    [Required]
    public string Description { get; set; }

    public bool AddToCart { get; set; } = false;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;


    public int UserId { get; set; }
    public User? Admin { get; set; }
}