using Application.DTO;
using Application.Services.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TinTestMVC.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{

    private readonly ICourseService _courseService;
    private readonly ITutorService _tutorService;

    public AdminController(ICourseService courseService, ITutorService tutorService)
    {
        _courseService = courseService;
        _tutorService = tutorService;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    [HttpGet]
    public async Task<IActionResult> AddCourse()
    {
        var tutors = await _tutorService.GetTutors();
        var model = new NewCourseDTO();
        ViewBag.Tutors = tutors;
            
        return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddNewCourse(NewCourseDTO course)
    {
        if (!ModelState.IsValid)
        {
            var tutors = await _tutorService.GetTutors();
            ViewBag.Tutors = tutors;
            return View("AddCourse", course);
        }
        
        await _courseService.AddNewCourse(course);

        TempData["Success"] = "Dodano nowy kurs pomyślnie!";
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public IActionResult AddTutor()
    {
        return View(new TutorDTO());
    }
    
    [HttpPost]
    public async Task<IActionResult> AddTutor(TutorDTO dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }

        await _tutorService.AddNewTutorAsync(dto);

        TempData["Success"] = "Dodano nowego nauczyciela pomyślnie!";
        return RedirectToAction("Index");
    }
    
    
    [HttpGet]
    public async Task<IActionResult> EditCourseSelect()
    {
        var courses = await _courseService.GetCoursesDetails();
        return View(courses);
    }
    
    
    
    [HttpGet]
    public async Task<IActionResult> EditCourse(int id)
    {
        if (id <= 0)
        {
            TempData["Error"] = "Nie wybrano kursu do edycji.";
            return RedirectToAction("EditCourseSelect");
        }

        var courseDetails = await _courseService.GetCourseDetails(id);

        var model = new EditCourseDTO
        {
            Description = courseDetails.Description,
            Price = courseDetails.Price,
            StartDate = courseDetails.StartDate,
            EndDate = courseDetails.EndDate
        };

        ViewBag.CourseId = id;
        return View(model);
    }


    
    [HttpPost]
    public async Task<IActionResult> EditCourse(int id, EditCourseDTO dto)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.CourseId = id;
            return View(dto);
        }

        var result = await _courseService.UpdateCourseAsync(id, dto);

        if (result == 0)
        {
            TempData["Error"] = "Nie udało się zaktualizować kursu (kurs nie istnieje?).";
            return RedirectToAction("EditCourseSelect");
        }

        TempData["Success"] = "Pomyślnie zaktualizowano kurs.";
        return RedirectToAction("EditCourseSelect");
    }

    [HttpGet]
    public async Task<IActionResult> DeleteCourseSelect()
    {
        var courses = await _courseService.GetCoursesDetails();
        return View(courses);
    }

    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteCourse(int id)
    {
        if (id <= 0)
        {
            TempData["Error"] = "Nie wybrano kursu do usunięcia.";
            return RedirectToAction("DeleteCourseSelect");
        }

        var result = await _courseService.DeleteCourseByID(id);
        if (result == 0)
        {
            TempData["Error"] = "Nie znaleziono kursu o podanym ID lub usunięcie się nie powiodło.";
        }
        else
        {
            TempData["Success"] = "Pomyślnie usunięto kurs.";
        }

        return RedirectToAction("DeleteCourseSelect");
    }
}