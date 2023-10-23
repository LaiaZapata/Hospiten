using Hospiten.Core.Application.Interface.Repository;
using Hospiten.Core.Application.ViewModel.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospiten.Core.Application.Interface.Services
{
    public interface IAppointmentService : IGenericService<SaveAppointmentViewModel, AppointmentViewModel>
    {
        Task<List<AppointmentViewModel>> GetAllViewModelWithFilters(FilterAppointmentViewModel filters);
    }
}
