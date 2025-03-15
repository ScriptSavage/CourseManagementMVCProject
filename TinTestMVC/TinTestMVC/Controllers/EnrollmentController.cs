using System.Security.Claims;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TinTestMVC.Controllers;

[Authorize]
public class EnrollmentController : Controller
{
    private readonly IPersonCourseService _personCourseService;
    private readonly IPersonService _service;
    private readonly ICourseService _courseService;

    public EnrollmentController(IPersonCourseService personCourseService, IPersonService service, ICourseService courseService)
    {
        _personCourseService = personCourseService;
        _service = service;
        _courseService = courseService;
    }

    [HttpGet]
    public async Task<IActionResult> Register(int courseId)
    {
        var course = await _courseService.GetCourseDetails(courseId);
        if (course == null)
        {
            TempData["Error"] = "Nie znaleziono kursu o podanym ID.";
            return RedirectToAction("Index", "Course");
        }

        ViewBag.CourseId = courseId;
        ViewBag.CourseName = course.Title; 

        return View();
    }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterFourCourse(int courseId)
        {
            if (courseId <= 0)
            {
                TempData["Error"] = "Nieprawidłowy identyfikator kursu.";
                return RedirectToAction("Register");
            }

            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            if (string.IsNullOrEmpty(userEmail))
            {
                TempData["Error"] = "Nie można zidentyfikować zalogowanego użytkownika.";
                return RedirectToAction("Register");
            }

            var person = await _service.GetByEmailAsync(userEmail);
            if (person == null)
            {
                TempData["Error"] = "Błąd: nie znaleziono Twojego rekordu w bazie Persons.";
                return RedirectToAction("Register");
            }

            var course = await _courseService.GetCourseDetails(courseId);
            if (course == null)
            {
                TempData["Error"] = "Kurs o podanym ID nie istnieje.";
                return RedirectToAction("Register");
            }

            int personId = person.Id;

            int currentNumberOfStudents = await _courseService.GetCurrentNumberOfStudentsAsync(courseId);
            if (currentNumberOfStudents >= course.MaxNumberOfStudents)
            {
                TempData["Error"] = "Kurs osiągnął maksymalną liczbę studentów.";
                return RedirectToAction("Register", new { courseId });
            }

            var success = await _personCourseService.EnrollPersonInCourse(personId, courseId);

            if (!success)
            {
                TempData["Error"] = "Już jesteś zapisany na ten kurs lub wystąpił błąd.";
                return RedirectToAction("Register", new { courseId });
            }

            TempData["Success"] = "Pomyślnie zapisałeś się na kurs!";
            return RedirectToAction("Confirmation");
        }

    public IActionResult Confirmation()
    {
        return View();
    }
    
    [HttpGet]
    public async Task<IActionResult> MyCourses()
    {
        var userEmail = User.Identity.Name; 
       
        var person = await _service.GetByEmailAsync(userEmail);
        if (person == null)
        {
            TempData["Error"] = "Nie znaleziono Twojego rekordu w tabeli Persons.";
            return RedirectToAction("Index", "Home");
        }
        
        int personId = person.Id;
        
        var userCourses = await _personCourseService.GetUserCoursesAsync(personId);

        return View(userCourses); 
    }
}