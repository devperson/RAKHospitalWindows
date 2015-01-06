using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RAKHospitalAdmin.Models
{
    /// <summary>
    /// This is a Doctor class subclass of person. It also is mapped to Doctor database table.
    /// </summary>
    public class Doctor : Person
    {
        public double Salary { get; set; }
        public Specialization Specialization { get; set; }
        public int SpecializationID { get; set; }
        public List<Patient> Patients { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
