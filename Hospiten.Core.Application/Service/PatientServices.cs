using Hospiten.Core.Application.Interface.Repository;
using Hospiten.Core.Application.Interface.Services;
using Hospiten.Core.Application.ViewModel.Doctor;
using Hospiten.Core.Application.ViewModel.Patient;
using Hospiten.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hospiten.Core.Application.Service
{
    public class PatientServices : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientServices(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task Update(SavePatientViewModel vm)
        {
            Patient patient = await _patientRepository.GetByIdAsync(vm.Patient_Id);
            patient.Patient_Id = vm.Patient_Id;
            patient.Name = vm.Name;
            patient.Lastname = vm.Lastname;
            patient.Email = vm.Email;
            patient.Phone_Number = vm.Phone_Number;
            patient.Cedula = vm.Cedula;
            patient.Photo = vm.Photo;
            patient.Address = vm.Address;
            patient.Smokes = vm.Smokes;
            patient.dateB = vm.dateB;
            patient.Allergi = vm.Allergi;


            await _patientRepository.Updatesync(patient);
        }

        public async Task<SavePatientViewModel> Add(SavePatientViewModel vm)
        {
            Patient patient = new();
            patient.Name = vm.Name;
            patient.Lastname = vm.Lastname;
            patient.Email = vm.Email;
            patient.Phone_Number = vm.Phone_Number;
            patient.Cedula = vm.Cedula;
            patient.Photo = vm.Photo;
            patient.Address = vm.Address;
            patient.Smokes = vm.Smokes;
            patient.dateB = vm.dateB;
            patient.Allergi = vm.Allergi;

            patient = await _patientRepository.AddAsync(patient);

            SavePatientViewModel patientvm = new();
            patientvm.Patient_Id = patient.Patient_Id;
            patientvm.Name = patient.Name;
            patientvm.Lastname = patient.Lastname;
            patientvm.Email = patient.Email;
            patientvm.Phone_Number = patient.Phone_Number;
            patientvm.Cedula = patient.Cedula;
            patientvm.Photo = patient.Photo;
            patientvm.Address = patient.Address;
            patientvm.Smokes = patient.Smokes;
            patientvm.dateB = patient.dateB;
            patientvm.Allergi = patient.Allergi;

            return patientvm;
        }

        public async Task Delete(int id)
        {
            var product = await _patientRepository.GetByIdAsync(id);
            await _patientRepository.Deletesync(product);
        }

        public async Task<SavePatientViewModel> GetByIdSaveViewModel(int id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);

            SavePatientViewModel vm = new();
            vm.Patient_Id = patient.Patient_Id;
            
            vm.Name = patient.Name;
            vm.Lastname = patient.Lastname;
            vm.Email = patient.Email;
            vm.Phone_Number = patient.Phone_Number;
            vm.Cedula = patient.Cedula;
            vm.Photo = patient.Photo;
            vm.Address = patient.Address;
            vm.Smokes = patient.Smokes;
            vm.dateB = patient.dateB;
            vm.Allergi = patient.Allergi;

            return vm;
        }

        public async Task<List<PatientViewModel>> GetAllViewModel()
        {
            var PatientList = await _patientRepository.GetAllAsync();
            return PatientList.Select(patient => new PatientViewModel
            {
                Patient_Id = patient.Patient_Id,
                Name = patient.Name,
                Lastname = patient.Lastname,
                Address = patient.Address,
                Phone_Number = patient.Phone_Number,
                Cedula = patient.Cedula,
                Email = patient.Email,
                Photo = patient.Photo,
                Allergi = patient.Allergi,
                Smokes = patient.Smokes,
                dateB = patient.dateB

            }).ToList();
        }

   
        public async Task<List<PatientViewModel>> GetAllViewModelWithFilters(FilterPatientViewModel filters)
        {
            var patientList = await _patientRepository.GetAllWithIncludeAsync(new List<string> { "Patient" });

            var listViewModels = patientList.Select(patient => new PatientViewModel
            {
                Patient_Id = patient.Patient_Id,
                Name = patient.Name,
                Lastname = patient.Lastname,
                Address = patient.Address,
                Phone_Number = patient.Phone_Number,
                Cedula = patient.Cedula,
                Email = patient.Email,
                Photo = patient.Photo,
                Allergi = patient.Allergi,
                Smokes = patient.Smokes,
                dateB = patient.dateB
            }).ToList();

            if (filters.Patient_Id != null)
            {
                listViewModels = listViewModels.Where(product => product.Patient_Id == filters.Patient_Id.Value).ToList();
            }

            return listViewModels;
        }
    }
}
