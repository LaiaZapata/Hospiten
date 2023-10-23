using Microsoft.AspNetCore.Mvc;
using Hospiten.Core.Application.Interface.Services;
using Hospiten.Core.Application.ViewModel.Doctor;
using Hospiten.Infrastructure.Persistence.Contexts;
using System.Threading.Tasks;
using Hospiten.Core.Application.Service;
using Hospiten.Core.Application.ViewModel.Laboratory;

namespace WebApp.Hospiten.Controllers
{
    public class LaboratoryController : Controller
    {
        private readonly ILaboratoryService _laboratoryService;
        private readonly IPatientService _patientService;
        private readonly IExamService _examService;
        public LaboratoryController(ILaboratoryService laboratoryService, IPatientService patientService, IExamService examService)
        {
            _laboratoryService = laboratoryService;
            _patientService = patientService;
            _examService = examService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _laboratoryService.GetAllViewModel());
        }
        public async Task<IActionResult> Create()
        {

            SaveLaboratoryViewModel vm = new();
            vm.Patients = await _patientService.GetAllViewModel();
            vm.Exams = await _examService.GetAllViewModel();
            return View("SaveLaboratory", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(SaveLaboratoryViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Patients = await _patientService.GetAllViewModel();
                vm.Exams = await _examService.GetAllViewModel();
                return View("SaveLaboratory", vm);
            }

            await _laboratoryService.Add(vm);  
            return RedirectToRoute(new { controller = "Laboratory", action = "Index" });
        }
        public async Task<IActionResult> Edit(int id)
        {
            SaveLaboratoryViewModel vm = await _laboratoryService.GetByIdSaveViewModel(id);
            vm.Patients = await _patientService.GetAllViewModel();
            vm.Exams = await _examService.GetAllViewModel();
            return View("SaveLaboratory", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SaveLaboratoryViewModel vm)
        {
            if (!ModelState.IsValid)
            {
               
                vm.Patients = await _patientService.GetAllViewModel();
                vm.Exams = await _examService.GetAllViewModel();
                return View("SaveLaboratory", vm);
            }

            await _laboratoryService.Update(vm);
            return RedirectToRoute(new { controller = "Laboratory", action = "Index" });
        }
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _laboratoryService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int Lab_Id)
        {

            await _laboratoryService.Delete(Lab_Id);
            return RedirectToRoute(new { controller = "Laboratory", action = "Index" });
        }
    }

}
