using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurveyValidations.Models;

namespace DojoSurveyValidations.Controllers;

public class HomeController : Controller
{
    static Survey survey;
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
    public IActionResult Process(Survey newSurvey)
    {

        if(ModelState.IsValid)
        {

        }
        else {
            return View("Index");
        }
        // HttpContext.Session.SetString("Name", $"{survey.Name}");
        // HttpContext.Session.SetString("Location", $"{survey.Location}");
        // HttpContext.Session.SetString("Language", $"{survey.Language}");
        // HttpContext.Session.SetString("Comment", $"{survey.Comment}");
        survey = newSurvey;
        Console.WriteLine(survey.Comment);
        return RedirectToAction ("Display");
    }
    
    [HttpGet("display")]
    public IActionResult Display()
    {
        return View("display", survey);
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
