using Hospiten.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospiten.Core.Application.ViewModel.Doctor
{
    public class DoctorViewModel
    {
        public int Doctor_Id { get; set; }
        public string Name { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string phone_Number { get; set; }
        public string Cedula { get; set; }
        public string photo { get; set; }

    }
}
