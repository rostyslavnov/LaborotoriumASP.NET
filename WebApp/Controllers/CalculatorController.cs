using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class CalculatorController : Controller
{
    public IActionResult Form()
    {
        return View();
    }
    
    public IActionResult Result(Calculator model)
    {
        if (!model.IsValid())
        {
            return View("Error");
        }
        return View(model);
    }
    
}

public enum Operator
    {
        Add, Sub, Mul, Div, Pow, Sin
    }
    
