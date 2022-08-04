using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maternity.Models
{
    public class MotherModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }
        public List<int> BabyList { get; set; }
    }
}