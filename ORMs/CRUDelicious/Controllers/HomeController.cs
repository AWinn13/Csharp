using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        List<Dish> AllDishes = _context.Dishes.OrderByDescending(d => d.CreatedAt).ToList();
        return View("Index", AllDishes);
    }

    [HttpGet("Dishes/New")]
    public IActionResult RenderCreate()
    {
        return View("Create");
    }

    [HttpPost("Dishes/Create")]
    public IActionResult Create(Dish newDish)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            // call the method to render the create page
            return RenderCreate();
        }
    }

    [HttpGet("Dishes/{id}")]
    public IActionResult Read(int id)
    {
        Dish? OneDish = _context.Dishes.FirstOrDefault(d => d.DishId == id);
        return View("Read", OneDish);
    }
// ----------------Render Edit Page-------------------
    [HttpGet("Dishes/{id}/edit")]
    public IActionResult Edit(int id)
    {
        Dish? DishToEdit = _context.Dishes.FirstOrDefault(i => i.DishId == id);
        return View("Edit", DishToEdit);
    }

    [HttpPost("Dishes/{id}/update")]
    public IActionResult Update(Dish newDish, int id)
    {
        Dish? OldDish = _context.Dishes.FirstOrDefault(i => i.DishId == id);
        if (ModelState.IsValid)
        {
            OldDish.Name = newDish.Name;
            OldDish.Chef = newDish.Chef;
            OldDish.Tastiness = newDish.Tastiness;
            OldDish.Calories = newDish.Calories;
            OldDish.Description = newDish.Description;
            OldDish.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View("Edit", OldDish);
        }
    }

    [HttpPost("Dishes/{id}/Destroy")]
    public IActionResult Destroy(int id)
    {
        Dish? DishToDelete = _context.Dishes.SingleOrDefault(i => i.DishId == id);
        _context.Dishes.Remove(DishToDelete);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }





    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
