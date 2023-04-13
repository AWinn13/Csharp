#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace ChefsNDishes.Models;

public class MyContext : DbContext 
{   
    // This line will always be here. It is what constructs our context upon initialization  
    public MyContext(DbContextOptions options) : base(options) { }    
 
    public DbSet<Chef> Chefs { get; set; } 
    public DbSet<Dish> Dishes { get; set; } 
}