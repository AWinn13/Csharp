using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("/")]
    public IActionResult Index()
    {
        return View("Index");
    }
    
// -----------------CREATE NEW USER---------------------------------------------
    [HttpPost("/users/create")]
    public IActionResult CreateUsers(User newUser)
    {
        if (ModelState.IsValid)
        {

            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
            _context.Add(newUser);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("UserId", newUser.UserId);
            HttpContext.Session.SetString("FirstName", newUser.FirstName);
            return RedirectToAction("ViewWeddings");
        }
        else
        {
            return Index();

        }

    }

// -----------------------LOGIN USER----------------------------------------
    [HttpPost("/users/login")]
    public IActionResult Login(LoginUser userSubmission)
    {
        if (ModelState.IsValid)
        {
            User? userInDb = _context.Users.FirstOrDefault(u => u.Email == userSubmission.UserEmail);
            if (userInDb == null)
            {
                ModelState.AddModelError("Email", "Invalid Email/Password");
                return Index();
            }

            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();

            var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.UserPassword);

            if (result == 0)
            {
                ModelState.AddModelError("Password", "Invalid Email/Password");
                return View("Index");
            }
            HttpContext.Session.SetInt32("UserId", userInDb.UserId);
            HttpContext.Session.SetString("FirstName", userInDb.FirstName);
            return RedirectToAction("ViewWeddings");
        }
        else
        {
            return View("Index");
        }
    }

// -------------------------DASHBOARD/VIEW ALL-------------------------------------
    [SessionCheck]
    [HttpGet("/weddings")]
    public IActionResult ViewWeddings()
    {
        MyViewModel viewModel = new MyViewModel
        {
            AllWeddings = _context.Weddings.Include(a => a.Guests).ThenInclude(u => u.User).ToList(),
            Wedding = new Wedding()
        };
        return View("Weddings", viewModel);
    }


// ------------------------------VIEW WEDDING FORM -------------------------------
    [SessionCheck]
    [HttpGet("/weddings/create")]
    public IActionResult ViewWeddingForm()
    {


        return View("WeddingForm");
    }

// ------------------------------VIEW SINGLE WEDDING------------------------
    [SessionCheck]
    [HttpGet("/weddings/{WeddingId}")]
    public IActionResult ViewOneWedding(int WeddingId)
    {
        MyViewModel viewModel = new MyViewModel
        {

            Wedding = _context.Weddings.FirstOrDefault(a => a.WeddingId == WeddingId),
            AllGuests = _context.Guests.Include(a => a.User).Include(a => a.Wedding).Where(a => a.WeddingId == WeddingId).ToList()
        };
        return View("OneWedding", viewModel);
    }

// ---------------------------CREATE WEDDING--------------------------------------------
    [HttpPost("/weddings/create/new")]
    public IActionResult CreateWedding(Wedding newWedding)
    {
        newWedding.UserId = (int)HttpContext.Session.GetInt32("UserId");
        if (ModelState.IsValid)
        {
            _context.Add(newWedding);
            _context.SaveChanges();
            int newWeddingId = newWedding.WeddingId;
            return RedirectToAction("ViewOneWedding", new { WeddingId = newWeddingId });
        }
        else
        {
            return RedirectToAction("ViewWeddingForm");

        }
    }

    // ------------------------------ADD GUEST--------------------------------------
    [HttpPost("/weddings/{WeddingId}/rsvp/update")]
    public IActionResult RSVPWedding(Guest newGuest, int WeddingId)
    {
        newGuest.WeddingId = WeddingId;
        newGuest.UserId = (int)HttpContext.Session.GetInt32("UserId");
        if (ModelState.IsValid)
        {
            _context.Add(newGuest);
            _context.SaveChanges();
            return RedirectToAction("ViewWeddings");
        }
        else
        {
            return RedirectToAction("ViewWeddingForm");

        }
    }

    // --------------------------------DELETE GUEST-----------------------------
    [HttpPost("/weddings/{WeddingId}/rsvp/destroy")]
    public IActionResult LeaveWedding(int WeddingId)
    {
        Guest? DeleteGuest = _context.Guests.FirstOrDefault(g => g.WeddingId == WeddingId && g.UserId == (int)HttpContext.Session.GetInt32("UserId"));
        _context.Guests.Remove(DeleteGuest);
        _context.SaveChanges();
        return RedirectToAction("ViewWeddings");
    }

    // -------------------------DELETE WEDDING-----------------------------------------------------
    [HttpPost("weddings/{WeddingId}/destroy")]
    public IActionResult Destroy(int id)
    {
        Wedding? WeddingToDelete = _context.Weddings.SingleOrDefault(i => i.WeddingId == id);
        _context.Weddings.Remove(WeddingToDelete);
        _context.SaveChanges();
        return RedirectToAction("ViewWeddings");
    }

    // --------------------------------LOGOUT----------------------------------------------
    [HttpGet("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
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
public class SessionCheckAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // Find the session, but remember it may be null so we need int?
        int? userId = context.HttpContext.Session.GetInt32("UserId");
        // Check to see if we got back null
        if (userId == null)
        {
            // Redirect to the Index page if there was nothing in session
            // "Home" here is referring to "HomeController", you can use any controller that is appropriate here
            context.Result = new RedirectToActionResult("Index", "Home", "/");
        }
    }
}



