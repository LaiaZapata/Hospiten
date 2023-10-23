using Hospiten.Core.Application.Interface.Repository;
using Hospiten.Core.Application.ViewModel.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospiten.Core.Application.Interface.Services
{
    public interface IDoctorService : IGenericService<SaveDoctorViewModel, DoctorViewModel>
    {
        Task<List<DoctorViewModel>> GetAllViewModelWithFilters(FilterDoctorViewModel filters);
    }
}
