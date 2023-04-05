using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurveyValidations.Models;

namespace DojoSurveyValidations.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    [HttpGet("")]
    public IActionResult Index()
    {
        return View("index");
    }

    [HttpPost("process")]
    public IActionResult Process(Survey survey)
    {
        HttpContext.Session.SetString("Name", $"{survey.Name}");
        HttpContext.Session.SetString("Location", $"{survey.Location}");
        HttpContext.Session.SetString("Language", $"{survey.Language}");
        HttpContext.Session.SetString("Comment", $"{survey.Comment}");
        Console.WriteLine(survey.Comment);
        return RedirectToAction ("Display");
    }
    
    [HttpGet("display")]
    public IActionResult Display(Survey survey)
    {
        
        return View("display");
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
