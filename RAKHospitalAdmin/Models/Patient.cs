using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RAKHospitalAdmin.Models
{
    /// <summary>
    /// This is a Doctor class subclass of person. It also is mapped to Doctor database table
    /// </summary>
    public class Patient : Person
    {
        public Doctor Doctor { get; set; }
        public DateTime DateAdmitted { get; set; }
        public DateTime? DateDischarged { get; set; }
        public Room RoomCategory { get; set; }
        public int DoctorID { get; set; }
        public int RoomID { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
