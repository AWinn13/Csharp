using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChefsNDishes.Models;

namespace ChefsNDishes.Controllers;

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
        List<Chef> AllChefs = _context.Chefs.OrderByDescending(d => d.CreatedAt).Include(i => i.AllDishes).ToList();
        return View("Index",AllChefs);
    }
    [HttpGet("dishes")]
    public IActionResult ViewDishes()
    {
        List<Dish> AllDishes = _context.Dishes.Include(d => d.Chef).ToList();
        return View("ViewDish", AllDishes);
    }

    [HttpGet("chefs/new")]
    public IActionResult NewChef()
    {

        return View("AddChef");
    }
    
    [HttpPost("chefs/new/create")]
    public IActionResult CreateChef(Chef addChef)
    {
        if (ModelState.IsValid)
        {
            _context.Add(addChef);
            _context.SaveChanges();
            return Index();
        }
        else
        {
            return View("AddChef");
        }
    }

    [HttpGet("dishes/new")]
    public IActionResult NewDish()
    {
        var model = new Dish();
        model.AllChefs =  _context.Chefs.ToList();
        return View("AddDish", model);
    }


    [HttpPost("dishes/new/create")]
    public IActionResult CreateDish(Dish addDish)
    {
        if (ModelState.IsValid)
        {
            _context.Add(addDish);
            _context.SaveChanges();
            return ViewDishes();
        }
        else
        {
            return NewDish();
        }
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
