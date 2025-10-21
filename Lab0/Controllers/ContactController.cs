using Lab0.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab0.Controllers;

public class ContactController : Controller
{
    private static Dictionary<int, Contact> _contacts = new();

    private static int i = 0;
    // GET
    public IActionResult Index()
    {
        return View(_contacts.Values.ToList());
    }

    [HttpGet]   // wyświetlenie formularza dodania obiektu
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost] //odbior danych obiektu i zapisanie do bazy
    public IActionResult Create(Contact model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        // zapisanie obiektu
        model.Id = ++i;
        _contacts.Add(model.Id, model);
        return RedirectToAction("Index");   // przejdź do listy obiektów
    }
}