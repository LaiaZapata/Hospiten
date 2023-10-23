using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospiten.Core.Domain.Entities
{
    public class Users
    {
        public int User_Id { get; set; }
        public string User_Name { get; set;}
        public string User_Email { get; set;}
        public string User_Password { get; set;}
        public string User_type { get; set;}
    }
}
