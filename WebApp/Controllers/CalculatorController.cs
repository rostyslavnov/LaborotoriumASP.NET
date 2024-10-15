using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class CalculatorController : Controller
{
    public IActionResult Calculator(Operator? op, double? x, double? y)
    {



        if (op == Operator.Sin)
        {
            if (x is null)
            {
                ViewBag.ErrorMessage = "Niepoprawny format parametru x.";
                return View("CalculatorError");
            }

            ViewBag.Result = Math.Sin(x.Value);
            return View();
        }



        if (x is null || y is null)
        {
            ViewBag.ErrorMessage = "Niepoprawny format parametru x lub y";
            return View("CalculatorError");
        }

        if (op is null)
        {
            ViewBag.ErrorMessage = "Nieznany operator!";
            return View("CalculatorError");
        }

        switch (op)
        {
            case Operator.Add:
                ViewBag.Result = x + y;
                break;
            case Operator.Div:
                ViewBag.Result = x - y;
                break;
            case Operator.Mul:
                ViewBag.Result = x * y;
                break;
            case Operator.Sub:
                ViewBag.Result = x / y;
                break;
            case Operator.Pow:
                ViewBag.Result = Math.Pow(x.Value, y.Value);
                break;
            case Operator.Sin:

                ViewBag.Result = Math.Sin(x.Value);
                break;
        }

        return View();
    }
    public IActionResult Form()
    {
        return View();
    }
}

public enum Operator
    {
        Add, Sub, Mul, Div, Pow, Sin
    }
    
