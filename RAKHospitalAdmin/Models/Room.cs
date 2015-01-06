using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RAKHospitalAdmin.Models
{
    /// <summary>
    /// This is a Doctor class it represents Room database table.
    /// </summary>
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public List<Patient> Patients { get; set; }
    }
}
