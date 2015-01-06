using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;

namespace RAKHospitalAdmin.Models
{    
    public class SpecializationRepository : Repository<Specialization>
    {
        public SpecializationRepository()
            : this(new DataBaseContext())
        {
        }
        public SpecializationRepository(DbContext context)
            : base(context)
        {
        }      
    }

    public class DoctorRepository : Repository<Doctor>
    {
        public DoctorRepository()
            : this(new DataBaseContext())
        {
        }
        public DoctorRepository(DbContext context)
            : base(context)
        {
        }

        public IEnumerable<Doctor> GetIgerly()
        {
            return this._context.Set<Doctor>().Include("Specialization").AsEnumerable();
        }
    }

    public class PatientRepository : Repository<Patient>
    {
        public PatientRepository(DbContext context)
            : base(context)
        {
        }
        public PatientRepository()
            : this(new DataBaseContext())
        {
        }

        public IEnumerable<Patient> GetIgerly()
        {
            return this._context.Set<Patient>().Include("Doctor").Include("RoomCategory").AsEnumerable();
        }
    }

    public class RoomRepository : Repository<Room>
    {
        public RoomRepository(DbContext context)
            : base(context)
        {
        }
        public RoomRepository()
            : this(new DataBaseContext())
        {
        }       
    } 
}