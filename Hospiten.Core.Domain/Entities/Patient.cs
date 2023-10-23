using Hospiten.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospiten.Core.Domain.Entities
{
    public class Patient : AuditableBaseEntity
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
        public string? Allergi {  get; set; }

        //Nav property
        public ICollection<Appointments> Appointments { get; set; }
        public ICollection<Laboratory> Laboratories { get; set; }
        

    }
}
