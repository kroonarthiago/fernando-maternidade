using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maternity.Models
{
    public class Baby_DoctorModel
    {
        public int Id { get; set; }
        public int BabyId { get; set; }
        public int DoctorId { get; set; }
    }
}