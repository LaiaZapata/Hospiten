using Microsoft.AspNetCore.Mvc;
using Hospiten.Core.Application.Interface.Services;
using Hospiten.Core.Application.ViewModel.Doctor;
using Hospiten.Infrastructure.Persistence.Contexts;
using System.Threading.Tasks;
using Hospiten.Core.Application.Service;
using Hospiten.Core.Application.ViewModel.Appointment;

namespace WebApp.Hospiten.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;
        public AppointmentController(IAppointmentService appointmentService, IPatientService patientService, IDoctorService doctorService)
        {
            _appointmentService = appointmentService;
            _patientService = patientService;
            _doctorService = doctorService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _appointmentService.GetAllViewModel());
        }
        public async Task<IActionResult> Create()
        {
            SaveAppointmentViewModel vm = new();
            vm.Patients = await _patientService.GetAllViewModel();
            vm.Doctors = await _doctorService.GetAllViewModel();
            vm.Appointments = await _appointmentService.GetAllViewModel();
            return View("SaveAppointment", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(SaveAppointmentViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Patients = await _patientService.GetAllViewModel();
                vm.Doctors = await _doctorService.GetAllViewModel();
                vm.Appointments = await _appointmentService.GetAllViewModel();
                return View("SaveAppointment", vm);
            }

            await _appointmentService.Add(vm);
            return RedirectToRoute(new { controller = "Appointment", action = "Index" });
        }
        public async Task<IActionResult> Edit(int id)
        {
            SaveAppointmentViewModel vm = await _appointmentService.GetByIdSaveViewModel(id);
            vm.Patients = await _patientService.GetAllViewModel();
            vm.Doctors = await _doctorService.GetAllViewModel();
            vm.Appointments = await _appointmentService.GetAllViewModel();
            return View("SaveAppointmnet", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SaveAppointmentViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Patients = await _patientService.GetAllViewModel();
                vm.Doctors = await _doctorService.GetAllViewModel();
                vm.Appointments = await _appointmentService.GetAllViewModel();
                return View("SaveAppointment", vm);
            }

            await _appointmentService.Update(vm);
            return RedirectToRoute(new { controller = "Appointment", action = "Index" });
        }
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _appointmentService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int Ap_Id)
        {

            await _appointmentService.Delete(Ap_Id);
            return RedirectToRoute(new { controller = "Appointment", action = "Index" });
        }
    }

}
