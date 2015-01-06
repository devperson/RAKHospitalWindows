﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RAKHospitalAdmin.Models
{
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