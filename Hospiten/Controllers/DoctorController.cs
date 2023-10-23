using Microsoft.AspNetCore.Mvc;
using Hospiten.Core.Application.Interface.Services;
using Hospiten.Core.Application.ViewModel.Doctor;
using Hospiten.Infrastructure.Persistence.Contexts;
using System.Threading.Tasks;
using Hospiten.Core.Application.Service;

namespace WebApp.Hospiten.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _doctorService.GetAllViewModel());
        }
        public async Task<IActionResult> Create()
        {
            SaveDoctorViewModel vm = new();
            vm.Doctors = await _doctorService.GetAllViewModel();
            return View("SaveDoctor", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(SaveDoctorViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Doctors = await _doctorService.GetAllViewModel();
                return View("SaveDoctor", vm);
            }

            await _doctorService.Add(vm);
            return RedirectToRoute(new { controller = "Doctor", action = "Index" });
        }
        public async Task<IActionResult> Edit(int id)
        {
            SaveDoctorViewModel vm = await _doctorService.GetByIdSaveViewModel(id);
            vm.Doctors = await _doctorService.GetAllViewModel();
            return View("SaveDoctor", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SaveDoctorViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Doctors = await _doctorService.GetAllViewModel();
                return View("SaveDoctor", vm);
            }

            await _doctorService.Update(vm);
            return RedirectToRoute(new { controller = "Doctor", action = "Index" });
        }
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _doctorService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int Doctor_Id)
        {

            await _doctorService.Delete(Doctor_Id);
            return RedirectToRoute(new { controller = "Doctor", action = "Index" });
        }
    }

}
