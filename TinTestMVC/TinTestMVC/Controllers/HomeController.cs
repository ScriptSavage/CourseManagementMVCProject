using System.Diagnostics;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using TinTestMVC.Models;

namespace TinTestMVC.Controllers;

public class HomeController : Controller
{
    public async Task<IActionResult> Index()
    {
        return View();
    }

    
}