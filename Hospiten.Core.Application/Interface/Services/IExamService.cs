using Hospiten.Core.Application.Interface.Repository;
using Hospiten.Core.Application.ViewModel.Doctor;
using Hospiten.Core.Application.ViewModel.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospiten.Core.Application.Interface.Services
{
    public interface IExamService : IGenericService<SaveExamViewModel, ExamViewModel>
    {
        Task<List<ExamViewModel>> GetAllViewModelWithFilters(FilterExamViewModel filters);
    }
}
