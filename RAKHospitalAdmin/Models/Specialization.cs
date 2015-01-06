using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RAKHospitalAdmin.Models
{
    /// <summary>
    /// This is a Doctor class it represents Specialization database table.
    /// </summary>
    public class Specialization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Doctor> Doctors { get; set; }
    }
}
