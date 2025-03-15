using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TinTestMVC.Controllers;

public class TutorController : Controller
{
    private readonly ITutorService _service;

    public TutorController(ITutorService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetTutors()
    {
        var result = await _service.GetTutors();
        return View(result);
    }
}