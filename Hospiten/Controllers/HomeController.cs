using Hospiten.Controllers;
using Hospiten.Core.Application.Interface.Services;
using Hospiten.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hospiten.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPatientService _patientService;
        public HomeController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

