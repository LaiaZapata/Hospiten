using Hospiten.Core.Application.Interface.Repository;
using Hospiten.Core.Application.Interface.Services;
using Hospiten.Core.Application.ViewModel.Doctor;
using Hospiten.Core.Application.ViewModel.Exam;
using Hospiten.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospiten.Core.Application.Service
{
    public class ExamServices : IExamService
    {
        private readonly IExamRepository _ExamRepository;

        public ExamServices(IExamRepository ExamRepository)
        {
            _ExamRepository = ExamRepository;
        }

        public async Task Update(SaveExamViewModel vm)
        {
            Exams exam = await _ExamRepository.GetByIdAsync(vm.Exam_Id);
            exam.Exam_Id = vm.Exam_Id;
            exam.Exam_Name = vm.Exam_Name;
        

            await _ExamRepository.Updatesync(exam);
        }

        public async Task<SaveExamViewModel> Add(SaveExamViewModel vm)
        {
            Exams exam = new Exams();
            exam.Exam_Id = vm.Exam_Id;
            exam.Exam_Name = vm.Exam_Name;



            exam = await _ExamRepository.AddAsync(exam);

            SaveExamViewModel examvm = new SaveExamViewModel();
            examvm.Exam_Id = examvm.Exam_Id;
          

            return examvm;
        }

        public async Task Delete(int id)
        {
            var exam = await _ExamRepository.GetByIdAsync(id);
            await _ExamRepository.Deletesync(exam);
        }

        public async Task<SaveExamViewModel> GetByIdSaveViewModel(int id)
        {
            var exam = await _ExamRepository.GetByIdAsync(id);

            SaveExamViewModel vm = new SaveExamViewModel();
            vm.Exam_Id = exam.Exam_Id;
            vm.Exam_Name= exam.Exam_Name;
            return vm;
        }

        public async Task<List<ExamViewModel>> GetAllViewModel()
        {
            var ExamList = await _ExamRepository.GetAllAsync();
            return ExamList.Select(exam => new ExamViewModel
            {
                Exam_Id = exam.Exam_Id,
                Exam_Name = exam.Exam_Name,
            }).ToList();
        }

        public async Task<List<ExamViewModel>> GetAllViewModelWithFilters(FilterExamViewModel filters)
        {
            var ExamList = await _ExamRepository.GetAllWithIncludeAsync(new List<string> { "Exams" });

            var listViewModels = ExamList.Select(exam => new ExamViewModel
            {
                Exam_Id = exam.Exam_Id,
                Exam_Name = exam.Exam_Name,
            }).ToList();

            if (filters.Exam_Id != null)
            {
                listViewModels = listViewModels.Where(doctor => doctor.Exam_Id== filters.Exam_Id.Value).ToList();
            }

            return listViewModels;
        }
    }
}
