using Microsoft.AspNetCore.Mvc;
using Hospiten.Core.Application.Interface.Services;
using Hospiten.Core.Application.ViewModel.Patient;
using Hospiten.Infrastructure.Persistence.Contexts;
using System.Threading.Tasks;
using Hospiten.Core.Application.Service;

namespace WebApp.Hospiten.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _patientService.GetAllViewModel());
        }
        public async Task<IActionResult> Create()
        {
            SavePatientViewModel vm = new();
            vm.Patients = await _patientService.GetAllViewModel();
            return View("SavePatient", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(SavePatientViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Patients = await _patientService.GetAllViewModel();
                return View("SavePatient", vm);
            }

            await _patientService.Add(vm);
            return RedirectToRoute(new { controller = "Patient", action = "Index" });
        }
        public async Task<IActionResult> Edit(int id)
        {
            SavePatientViewModel vm = await _patientService.GetByIdSaveViewModel(id);
            vm.Patients = await _patientService.GetAllViewModel();
            return View("SavePatient", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SavePatientViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Patients = await _patientService.GetAllViewModel();
                return View("SavePatient", vm);
            }

            await _patientService.Update(vm);
            return RedirectToRoute(new { controller = "Patient", action = "Index" });
        }
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _patientService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int Patient_id)
        {

            await _patientService.Delete(Patient_id);
            return RedirectToRoute(new { controller = "Patient", action = "Index" });
        }
    }

}
