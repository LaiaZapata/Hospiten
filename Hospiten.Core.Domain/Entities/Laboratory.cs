using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospiten.Core.Domain.Entities
{
    public class Laboratory
    {
        public int Lab_Id { get; set; }
        public string Lab_Name { get; set; }
        public int Patient_Id { get; set; }
        public int Exam_Id { get; set; }
        public string Result { get; set; }  
        public string Description { get; set; }

        public Patient? Patient_Name { get; set; }
        public Exams? Exam_Name { get; set; }

    }
}
