#pragma warning disable CS8618
namespace ChefsNDishes.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


public class Dish
{
    [Key]
    public int DishId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    [Range(1, 5)]
    public int Tastiness { get; set; }
    [Required]
    [Range(0, 100000)]
    public int Calories { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public int ChefId { get; set; }
    public Chef? Chef { get; set; }
    
    [NotMapped]
    public List<Chef> AllChefs { get; set; } = new List<Chef>();
}


