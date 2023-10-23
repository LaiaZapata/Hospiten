using Hospiten.Core.Application.Interface.Repository;
using Hospiten.Infrastructure.Persistence.Contexts;
using Hospiten.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hospiten.Infrastructure.Persistence.Contexts.ApplicationContext;

namespace Hospiten.Infrastructure.Persistence
{
    //patron decorador - extension method
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfraestructure(this IServiceCollection services, IConfiguration config)
        {
            #region Connection
            bool useMemoryDatabase = config.GetValue<bool>("UseInMemoryDatabase");
            if (useMemoryDatabase)
            {

                services.AddDbContext<ApplicationDBContext>(options =>
                                        options.UseInMemoryDatabase("dbMemory"));


            }
            else
            {
                var connectionString = config.GetConnectionString("DefaultConnection");
                services.AddDbContext<ApplicationDBContext>(options =>
                                        options.UseSqlServer(connectionString, opt =>
                                            opt.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
            }
            #endregion

            #region Repositorios
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient<IDoctorRepository, DoctorRepository>();
            services.AddTransient<ILaboratoryRepository, LaboratoryRepository>();
            services.AddTransient<IExamRepository, ExamRepository>();
            services.AddTransient<IAppointmentRepository, AppointmentRepository>();

            #endregion

        }


    }
}
