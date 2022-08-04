using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maternity.Models
{
    public class DoctorModel
    {
        public int Id { get; set; }
        public string Crm { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public string Phone { get; set; }
        public List<int> BabysList { get; set; }
    }
}