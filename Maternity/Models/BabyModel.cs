using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maternity.Models
{
    public class BabyModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Height { get; set; }
        public int MotherId { get; set; }
        public List<int> DoctorList { get; set; }
    }
}