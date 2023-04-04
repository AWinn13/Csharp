using Microsoft.AspNetCore.Mvc;
namespace PortfolioI.Controllers;

public class PortfolioController : Controller
{
    [HttpGet]
    [Route("")]
    public string Index()
    {
        return "This is the index";
    }
    [HttpGet("projects")]
    public string Project()
    {
        return "These are my projects";
    }

    [HttpGet("contacts/{name}")]
    public string Contact(string name)
    {
        return $"This is my {name} contact";
    }
}