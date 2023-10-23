using Hospiten.Core.Application.Interface.Repository;
using Hospiten.Core.Application.Interface.Services;
using Hospiten.Core.Application.ViewModel.Laboratory;
using Hospiten.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Hospiten.Core.Application.Service
{
    public class LaboratoryServices : ILaboratoryService
    {
        private readonly ILaboratoryRepository _laboratoryRepository;
        private readonly IPatientRepository _patientRepository;
        public LaboratoryServices(ILaboratoryRepository laboratoryRepository, IPatientRepository patientRepository)
        {
            _laboratoryRepository = laboratoryRepository;
            _patientRepository = patientRepository;
        }

        public async Task Update(SaveLaboratoryViewModel vm)
        {
            Laboratory lab = await _laboratoryRepository.GetByIdAsync(vm.Lab_Id);
      
            lab.Lab_Id = vm.Lab_Id;
            lab.Lab_Name = vm.Lab_Name;
            lab.Patient_Id = vm.Patient_Id;
            lab.Exam_Id = vm.Exam_Id;
            lab.Result = vm.Result;
            lab.Description = vm.Description;

            await _laboratoryRepository.Updatesync(lab);
        }

        public async Task<SaveLaboratoryViewModel> Add(SaveLaboratoryViewModel vm)
        {
            Laboratory lab = new Laboratory();
            lab.Lab_Name = vm.Lab_Name;
            lab.Patient_Id = vm.Patient_Id;
            lab.Exam_Id = vm.Exam_Id;
            lab.Result = vm.Result;
            lab.Description = vm.Description;

            lab = await _laboratoryRepository.AddAsync(lab);

            SaveLaboratoryViewModel labvm = new SaveLaboratoryViewModel();
            labvm.Lab_Id = lab.Lab_Id;
            labvm.Lab_Name = lab.Lab_Name;
            labvm.Patient_Id = lab.Patient_Id;
            labvm.Exam_Id = lab.Exam_Id;
            labvm.Result = lab.Result;
            labvm.Description = lab.Description;
            return labvm;
        }

        public async Task Delete(int id)
        {
            var laboratory = await _laboratoryRepository.GetByIdAsync(id);
            await _laboratoryRepository.Deletesync(laboratory);
        }

        public async Task<SaveLaboratoryViewModel> GetByIdSaveViewModel(int id)
        {
            var lab = await _laboratoryRepository.GetByIdAsync(id);

            SaveLaboratoryViewModel labvm = new SaveLaboratoryViewModel();
            labvm.Lab_Id = lab.Lab_Id;
            labvm.Lab_Name = lab.Lab_Name;
            labvm.Patient_Id = lab.Patient_Id;
            labvm.Exam_Id = lab.Exam_Id;
            labvm.Result = lab.Result;
            labvm.Description = lab.Description;

            return labvm;
        }

        public async Task<List<LaboratoryViewModel>> GetAllViewModel()
        {
            var LabList = await _laboratoryRepository.GetAllAsync();
            return LabList.Select(laboratory => new LaboratoryViewModel
            {
             Lab_Id = laboratory.Lab_Id,
             Lab_Name = laboratory.Lab_Name,
             Patient_Id = laboratory.Patient_Id,
             Exam_Id = laboratory.Exam_Id,
             Result = laboratory.Result,
             Description = laboratory.Description,
        }).ToList();
        }

        public async Task<List<LaboratoryViewModel>> GetAllViewModelWithFilters(FilterLaboratoryViewModel filters)
        {
            var labList = await _laboratoryRepository.GetAllWithIncludeAsync(new List<string> { "Laboratory" });

            var listViewModels = labList.Select(laboratory => new LaboratoryViewModel
            {
                Lab_Id = laboratory.Lab_Id,
                Lab_Name = laboratory.Lab_Name,
                Patient_Id = laboratory.Patient_Id,
                Exam_Id = laboratory.Exam_Id,
                Result = laboratory.Result,
                Description = laboratory.Description,
            }).ToList();

            if (filters.Lab_Id != null)
            {
                listViewModels = listViewModels.Where(lab => lab.Lab_Id == filters.Lab_Id.Value).ToList();
            }

            return listViewModels;
        }
    }
}
