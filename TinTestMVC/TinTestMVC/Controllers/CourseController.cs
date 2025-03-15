using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TinTestMVC.Controllers;

public class CourseController : Controller
{
    private readonly ICourseService _service;

    public CourseController(ICourseService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 6)
    {
        var pagedResult = await _service.GetCoursesPaged(pageNumber, pageSize);
        return View(pagedResult);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var result = await _service.GetCourseDetails(id);
        return View(result);
    }
}