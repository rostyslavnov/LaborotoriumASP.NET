using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    /*
     * zdefiniuj metodę z widokiem Calculator, dodaj link nawigacijny do teh metody
     */
    public IActionResult Calculator(string op, double? x, double? y)
    {
        /*var op = Request.Query["op"];
        var x = double.Parse(Request.Query["x"]);
        var y = double.Parse(Request.Query["y"]);*/


        if (x is null || y is null)
        {
            ViewBag.ErrorMessage = "Niepoprawny format parametru x lub y";
            return View("CalculatorError");
        }
        
        
        switch (op)
        {
            case "add":
                ViewBag.Result = x + y;
                break;
            case "sub":
                ViewBag.Result = x - y;
                break;
            case "mul":
                ViewBag.Result = x * y;
                break;
            case "div":
                ViewBag.Result = x / y;
                break;
            default:
                ViewBag.ErrorMessage = "Nieznany operator!";
                return View("CalculatorError");
                
        }
        return View();
    }
    public IActionResult About()
    {
        return View();
    }

    public IActionResult Index()
    {
        return View();
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