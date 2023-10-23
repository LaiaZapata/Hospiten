using Hospiten.Core.Application.ViewModel.Patient;
using Hospiten.Core.Application.ViewModel.Exam;
using Hospiten.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospiten.Core.Application.ViewModel.Laboratory
{
    public class SaveLaboratoryViewModel
    {
        public int Lab_Id { get; set; }
        public string Lab_Name { get; set; }
        public int Patient_Id { get; set; }
        public int Exam_Id { get; set; }
        public string Result { get; set; }
        public string Description { get; set; }

        public List<LaboratoryViewModel>? Laboratories { get; set; }
        public List<ExamViewModel>? Exams { get; set; }
        public List<PatientViewModel>? Patients { get; set; }
    }
}
