using Microsoft.AspNetCore.Mvc;

namespace Lab0.Controllers;

public class CalculatorController : Controller
{
    // GET
    public IActionResult Form()
    {
        return View();
    }
    
    public IActionResult Result(double? a, double? b, [FromQuery(Name = "op")]string op)
    {
        string result = "";
        if (a is null || b is null)
        {
            return View("Calculator", "Brak parametru a lub b!");
        }
        switch (op)
        {
            case "add": result = $"{a} + {b} =  {a + b}";
                break;
            case "sub": result = $"{a} - {b} =  {a - b}";;
                break;
            case "mul": result =$"{a} * {b} =  {a * b}";;
                break;
            case "div": result =$"{a} / {b} =  {a / b}";;
                break;
            default:
                result = "Nieznany operator!";
                break;
        }
        ViewBag.Result = result;
        return View();
    }
    
    
}