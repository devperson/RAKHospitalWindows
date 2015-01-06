using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace RAKHospitalAdmin.Models
{    
    //These classes configures some of the mapping from Db table column to object properties, by default all mappings from db column to object properties happens by name matching.

    public class DoctorModelConfig : EntityTypeConfiguration<Doctor>
    {
        public DoctorModelConfig()
        {            
            HasKey(x => x.Id);
            this.HasRequired(x => x.Specialization).WithMany(c => c.Doctors).HasForeignKey(x => x.SpecializationID);            
        }
    }

    public class PatientModelConfig : EntityTypeConfiguration<Patient>
    {
        public PatientModelConfig()
        {
            HasKey(x => x.Id);
            this.HasRequired(x => x.Doctor).WithMany(c => c.Patients).HasForeignKey(x => x.DoctorID);
            this.HasRequired(x => x.RoomCategory).WithMany(c => c.Patients).HasForeignKey(x => x.RoomID);            
        }
    }

    public class SpecializationModelConfig : EntityTypeConfiguration<Specialization>
    {
        public SpecializationModelConfig()
        {
            this.HasKey(x => x.Id);            
        }
    }

    public class RoomModelConfig : EntityTypeConfiguration<Room>
    {
        public RoomModelConfig()
        {
            HasKey(x => x.Id);            
        }
    }   
}