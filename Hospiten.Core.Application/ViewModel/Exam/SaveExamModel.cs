using Hospiten.Core.Application.ViewModel.Exam;
using Hospiten.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospiten.Core.Application.ViewModel.Exam
{
    public class SaveExamViewModel
    {

        public int Exam_Id { get; set; }
        public string Exam_Name { get; set; }
        public List<ExamViewModel>? Exams { get; set; }
    }
}
