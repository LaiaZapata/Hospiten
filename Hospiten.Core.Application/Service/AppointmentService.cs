using Hospiten.Core.Application.Interface.Repository;
using Hospiten.Core.Application.Interface.Services;
using Hospiten.Core.Application.ViewModel.Appointment;
using Hospiten.Core.Application.ViewModel.Doctor;
using Hospiten.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospiten.Core.Application.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task Update(SaveAppointmentViewModel vm)
        {
            Appointments App = await _appointmentRepository.GetByIdAsync(vm.Ap_Id);
            App.Ap_Id = vm.Ap_Id;
            App.Patient_Id = vm.Patient_Id;
            App.Doctor_Id = vm.Doctor_Id;
            App.Ap_Date = vm.Ap_Date;
            App.Ap_hour = vm.Ap_hour;
            App.Ap_Status = vm.Ap_Status;
         

            await _appointmentRepository.Updatesync(App);
        }

        public async Task<SaveAppointmentViewModel> Add(SaveAppointmentViewModel vm)
        {
            Appointments App = new Appointments();
            App.Ap_Id = vm.Ap_Id;
            App.Patient_Id = vm.Patient_Id;
            App.Doctor_Id = vm.Doctor_Id;
            App.Ap_Date = vm.Ap_Date;
            App.Ap_hour = vm.Ap_hour;
            App.Ap_Status = vm.Ap_Status;


            App = await _appointmentRepository.AddAsync(App);

            SaveAppointmentViewModel Appvm = new SaveAppointmentViewModel();
            Appvm.Ap_Id = Appvm.Ap_Id;
            Appvm.Patient_Id = Appvm.Patient_Id;
            Appvm.Doctor_Id = Appvm.Doctor_Id;
            Appvm.Ap_Date= Appvm.Ap_Date;
            Appvm.Ap_hour= Appvm.Ap_hour;
            Appvm.Ap_Status= Appvm.Ap_Status;



            return Appvm;
        }

        public async Task Delete(int id)
        {
            var app = await _appointmentRepository.GetByIdAsync(id);
            await _appointmentRepository.Deletesync(app);
        }

        public async Task<SaveAppointmentViewModel> GetByIdSaveViewModel(int id)
        {
            var App = await _appointmentRepository.GetByIdAsync(id);


            SaveAppointmentViewModel Appvm = new SaveAppointmentViewModel();
            Appvm.Ap_Id = App.Ap_Id;
            Appvm.Patient_Id = App.Patient_Id;
            Appvm.Doctor_Id = App.Doctor_Id;
            Appvm.Ap_Date = App.Ap_Date;
            Appvm.Ap_hour = App.Ap_hour;
            Appvm.Ap_Status = App.Ap_Status;

            return Appvm;
        }

        public async Task<List<AppointmentViewModel>> GetAllViewModel()
        {
            var AppList = await _appointmentRepository.GetAllAsync();
            return AppList.Select(App => new AppointmentViewModel
            {
              Ap_Id = App.Ap_Id,
            Patient_Id = App.Patient_Id,
            Doctor_Id = App.Doctor_Id,
            Ap_Date = App.Ap_Date,
            Ap_hour = App.Ap_hour,
            Ap_Status = App.Ap_Status
        }).ToList();
        }

        public async Task<List<AppointmentViewModel>> GetAllViewModelWithFilters(FilterAppointmentViewModel filters)
        {
            var appList = await _appointmentRepository.GetAllWithIncludeAsync(new List<string> { "Appointment" });

            var listViewModels = appList.Select(App => new AppointmentViewModel
            {
                Ap_Id = App.Ap_Id,
                Patient_Id = App.Patient_Id,
                Doctor_Id = App.Doctor_Id,
                Ap_Date = App.Ap_Date,
                Ap_hour = App.Ap_hour,
                Ap_Status = App.Ap_Status
            }).ToList();

            if (filters.App_Id != null)
            {
                listViewModels = listViewModels.Where(app => app.Ap_Id == filters.App_Id.Value).ToList();
            }

            return listViewModels;
        }
    }
}
