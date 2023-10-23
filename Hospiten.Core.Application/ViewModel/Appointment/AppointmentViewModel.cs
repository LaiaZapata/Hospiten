using Hospiten.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospiten.Core.Application.ViewModel.Appointment
{
    public class AppointmentViewModel
    {
        public int Ap_Id { get; set; }
        public int Patient_Id { get; set; }
        public int Doctor_Id { get; set; }
        public string Ap_Date { get; set; }
        public string Ap_hour { get; set; }
        public string Ap_Status { get; set; }

       

    }
}
