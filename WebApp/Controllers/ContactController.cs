using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class ContactController: Controller
{


    private static Dictionary<int, ContactModel> _contacts = new()
    {
        {
            1,
            new ContactModel()
            {
                Id = 1,
                FirstName = "Adam",
                LastName = "Abecki",
                Email = "adam@wsei.edu.pl",
                PhoneNumber = "222 333 555",
                BirthDate = new DateOnly(200, 10, 10)
            }
        },
        {
            2,
            new ContactModel()
            {
                Id = 2,
                FirstName = "Ewa",
                LastName = "Sałatka",
                Email = "ewa@wsei.edu.pl",
                PhoneNumber = "777 333 555",
                BirthDate = new DateOnly(200, 10, 10)
            }
        },
        {
            3,
            new ContactModel()
            {
                Id = 3,
                FirstName = "Karol",
                LastName = "Marecki",
                Email = "karol@wsei.edu.pl",
                PhoneNumber = "111 333 666",
                BirthDate = new DateOnly(200, 10, 10)
            }
        },
    };

    private static int cucurrentId = 3;
    // Lista kontaktow
    public IActionResult Index()
    {
        return View(_contacts);
    }
    
    // Formularz dodawanie kontaktu
    public IActionResult Add()
    {
        return View();
    }
    
    // odberanie danych z formularza, walidacja i dodanie kontaktu do kolekcji
    [HttpPost]
    public IActionResult Add(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            // wyświetlenie ponowne formularza z błędami
            return View(model);
        }
        model.Id = ++cucurrentId;
        _contacts.Add(model.Id, model);
        return View("Index", _contacts);
    }

    
    //Delete
    public IActionResult Delete(int id)
    {
        _contacts.Remove(id);
        return View("Index", _contacts);
    }

    public IActionResult Edit()
    {
        throw new NotImplementedException();
    }

    public IActionResult Details()
    {
        throw new NotImplementedException();
    }
}