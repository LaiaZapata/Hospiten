using Hospiten.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospiten.Core.Application.ViewModel.Patient
{
    public class PatientViewModel
    {
        public int Patient_Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone_Number { get; set; }
        public string Cedula { get; set; }
        public string Photo { get; set; }
        public string Address { get; set; }
        public string Smokes { get; set; }
        public string dateB { get; set; }
        public string? Allergi { get; set; }

    }
}
