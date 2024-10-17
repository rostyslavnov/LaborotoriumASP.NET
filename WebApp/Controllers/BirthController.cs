using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class BirthController : Controller
    {
        public IActionResult Index()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Submit(Birth model)
        {
            if (model.IsValid())
            {
                int age = model.CalculateAge();
                ViewBag.Message = $"Cześć {model.Name}, masz {age} lat(a).";
            }
            else
            {
                ViewBag.Message = "Nieprawidłowe dane.";
            }

            return View("Index");
        }
    }
}