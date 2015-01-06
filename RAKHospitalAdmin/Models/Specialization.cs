﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RAKHospitalAdmin.Models
{
    public class Specialization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Doctor> Doctors { get; set; }
    }
}
