using Microsoft.AspNetCore.Mvc;
namespace RenderingViews.Controllers; 

public class SurveyController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        return View("index");
    }
    [HttpPost("process")]
    public IActionResult Process(string Name, string Location,  string Language, string Comments)
    {
        HttpContext.Session.SetString("Name", $"{Name}");
        HttpContext.Session.SetString("Location", $"{Location}");
        HttpContext.Session.SetString("Language", $"{Language}");
        HttpContext.Session.SetString("Comments", $"{Comments}");
        return RedirectToAction ("Display");
    }
    
    [HttpGet("results")]
    public ViewResult Display()
    {
        return View("display");
    }
}
