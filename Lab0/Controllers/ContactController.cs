using Lab0.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab0.Controllers;

public class ContactController : Controller
{
    private static Dictionary<int, Contact> _contacts = new(){
        { 1, new Contact() {Id = 1, Email = "ewa@wsei.edu.pl", Name = "ewa"} },
        { 2, new Contact() {Id = 2, Email = "adam@wsei.edu.pl", Name = "adaś"} }
    };

    private static int i = 2;
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

    public IActionResult Details(int id)
    {
        if (_contacts.ContainsKey(id))
        {
            return View(_contacts[id]);
        }
        else
        {
            return NotFound();
        }
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        if (_contacts.ContainsKey(id))
        {
            return View(_contacts[id]);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost]
    public IActionResult Edit(Contact model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        // aktualizacja obiektu
        _contacts[model.Id] = model;
        return RedirectToAction("Index"); 
    }
    
    [HttpGet]
    public IActionResult Delete(int id)
    {
        if (_contacts.ContainsKey(id))
        {
            return View(_contacts[id]);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost]
    public IActionResult DeleteConfirm(int id)
    {
        _contacts.Remove(id);
        return RedirectToAction("Index");
    }
    
    
}