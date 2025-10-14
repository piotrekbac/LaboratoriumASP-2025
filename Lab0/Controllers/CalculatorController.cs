using Lab0.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab0.Controllers;

public class CalculatorController : Controller
{
    // GET
    public IActionResult Form()
    {
        return View();
    }
    
    public IActionResult Result(CalculatorModel model)
    {
        if (!model.IsValid())
        {
            return View("Error", "Nie można obliczyć!");
        }
        
        ViewBag.Result = model.Result();
        return View();
    }
    
    
}