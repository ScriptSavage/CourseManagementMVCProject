using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TinTestMVC.Controllers;

public class PersonController : Controller
{
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService)
    {
        _personService = personService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var persons = await _personService.GetPersons();
        return View(persons);
    }
    
}