using Hospiten.Core.Application.Interface.Repository;
using Hospiten.Core.Application.ViewModel.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospiten.Core.Application.Interface.Services
{
    public interface IPatientService : IGenericService<SavePatientViewModel, PatientViewModel>
    {
        Task<List<PatientViewModel>> GetAllViewModelWithFilters(FilterPatientViewModel filters);
    }
}
