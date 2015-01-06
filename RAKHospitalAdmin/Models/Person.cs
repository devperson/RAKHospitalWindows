using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RAKHospitalAdmin.Models
{
    /// <summary>
    /// Base class for Doctor and Patient
    /// </summary>
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
