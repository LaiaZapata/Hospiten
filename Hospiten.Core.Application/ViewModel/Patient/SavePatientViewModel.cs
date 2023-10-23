using Hospiten.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospiten.Core.Application.ViewModel.Patient   
{
    public class SavePatientViewModel
    {

        [Required(ErrorMessage = "Debe colocar Datos")]
        public int Patient_Id { get; set; }
        [Required(ErrorMessage = "Debe colocar Datos")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Debe colocar Datos")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Debe colocar Datos")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Debe colocar Datos")]
        public string Phone_Number { get; set; }
        [Required(ErrorMessage = "Debe colocar Datos")]
        public string Cedula { get; set; }
        [Required(ErrorMessage = "Debe colocar Datos")]
        public string Photo { get; set; }
        [Required(ErrorMessage = "Debe colocar Datos")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Debe colocar Datos")]
        public string Smokes { get; set; }
        [Required(ErrorMessage = "Debe colocar Datos")]
        public string dateB { get; set; }
        [Required(ErrorMessage = "Debe colocar Datos")]
        public string? Allergi { get; set; }

        public List<PatientViewModel>? Patients { get; set; }
    }
}
