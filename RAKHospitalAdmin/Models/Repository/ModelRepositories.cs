using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;

namespace RAKHospitalAdmin.Models
{    
    /// <summary>
    /// This class provides database access for Specializations db table.
    /// </summary>
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

    /// <summary>
    /// This class provides database access for Doctors db table.
    /// </summary>
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

        /// <summary>
        /// Loads doctors including related Specialization data.
        /// </summary>        
        public IEnumerable<Doctor> GetIgerly()
        {
            return this._context.Set<Doctor>().Include("Specialization").AsEnumerable();
        }
    }

    /// <summary>
    /// This class provides database access for Patients db table.
    /// </summary>
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

        /// <summary>
        /// Loads doctors including related Doctor, RoomCategory data.
        /// </summary>        
        public IEnumerable<Patient> GetIgerly()
        {
            return this._context.Set<Patient>().Include("Doctor").Include("RoomCategory").AsEnumerable();
        }
    }

    /// <summary>
    /// This class provides database access for Rooms db table.
    /// </summary>
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