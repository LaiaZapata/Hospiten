using Hospiten.Core.Application.Interface.Services;
using Hospiten.Core.Application.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospiten.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            #region Services
            services.AddTransient<IPatientService, PatientServices>();
            services.AddTransient<IDoctorService, DoctorServices>();
            services.AddTransient<ILaboratoryService, LaboratoryServices>();
            services.AddTransient<IExamService, ExamServices>();
            services.AddTransient<IAppointmentService, AppointmentService>();

            #endregion
        }
    }
}
