using Hospiten.Core.Application.Interface.Repository;
using Hospiten.Core.Application.ViewModel.Laboratory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospiten.Core.Application.Interface.Services
{
    public interface ILaboratoryService : IGenericService<SaveLaboratoryViewModel, LaboratoryViewModel>
    {
        Task<List<LaboratoryViewModel>> GetAllViewModelWithFilters(FilterLaboratoryViewModel filters);
    }
}
