using Hospiten.Core.Application.Interface.Repository;
using Hospiten.Core.Application.Interface.Services;
using Hospiten.Core.Application.ViewModel.Doctor;
using Hospiten.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospiten.Core.Application.Service
{
    public class DoctorServices : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorServices(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task Update(SaveDoctorViewModel vm)
        {
            Doctors doctor = await _doctorRepository.GetByIdAsync(vm.Doctor_Id);
            doctor.Doctor_Id = vm.Doctor_Id;
            doctor.Name = vm.Name;
            doctor.lastname = vm.lastname;
            doctor.email = vm.email;
            doctor.phone_Number = vm.phone_Number;
            doctor.Cedula = vm.Cedula;
            doctor.photo = vm.photo;

            await _doctorRepository.Updatesync(doctor);
        }

        public async Task<SaveDoctorViewModel> Add(SaveDoctorViewModel vm)
        {
            Doctors doctor = new Doctors();
            doctor.Name = vm.Name;
            doctor.lastname = vm.lastname;
            doctor.email = vm.email;
            doctor.phone_Number = vm.phone_Number;
            doctor.Cedula = vm.Cedula;
            doctor.photo = vm.photo;

            doctor = await _doctorRepository.AddAsync(doctor);

            SaveDoctorViewModel doctorvm = new SaveDoctorViewModel();
            doctorvm.Doctor_Id = doctor.Doctor_Id;
            doctorvm.Name = doctor.Name;
            doctorvm.lastname = doctor.lastname;
            doctorvm.email = doctor.email;
            doctorvm.phone_Number = doctor.phone_Number;
            doctorvm.Cedula = doctor.Cedula;
            doctorvm.photo = doctor.photo;

            return doctorvm;
        }

        public async Task Delete(int id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);
            await _doctorRepository.Deletesync(doctor);
        }

        public async Task<SaveDoctorViewModel> GetByIdSaveViewModel(int id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);

            SaveDoctorViewModel vm = new SaveDoctorViewModel();
            vm.Doctor_Id = doctor.Doctor_Id;
            vm.Name = doctor.Name;
            vm.lastname = doctor.lastname;
            vm.email = doctor.email;
            vm.phone_Number = doctor.phone_Number;
            vm.Cedula = doctor.Cedula;
            vm.photo = doctor.photo;

            return vm;
        }

        public async Task<List<DoctorViewModel>> GetAllViewModel()
        {
            var DoctorList = await _doctorRepository.GetAllAsync();
            return DoctorList.Select(doctor => new DoctorViewModel
            {
                Doctor_Id = doctor.Doctor_Id,
                Name = doctor.Name,
                lastname = doctor.lastname,
                email = doctor.email,
                phone_Number = doctor.phone_Number,
                Cedula = doctor.Cedula,
                photo = doctor.photo
            }).ToList();
        }

        public async Task<List<DoctorViewModel>> GetAllViewModelWithFilters(FilterDoctorViewModel filters)
        {
            var doctorList = await _doctorRepository.GetAllWithIncludeAsync(new List<string> { "Doctors" });

            var listViewModels = doctorList.Select(doctor => new DoctorViewModel
            {
                Doctor_Id = doctor.Doctor_Id,
                Name = doctor.Name,
                lastname = doctor.lastname,
                email = doctor.email,
                phone_Number = doctor.phone_Number,
                Cedula = doctor.Cedula,
                photo = doctor.photo
            }).ToList();

            if (filters.Do_Id != null)
            {
                listViewModels = listViewModels.Where(doctor => doctor.Doctor_Id== filters.Do_Id.Value).ToList();
            }

            return listViewModels;
        }
    }
}
