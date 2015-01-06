using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RAKHospitalAdmin.Models
{
    /// <summary>
    /// This is EF data context class it holds all tables.
    /// </summary>
    public class DataBaseContext : DbContext
    {
        public DataBaseContext()
            : base("DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.AutoDetectChangesEnabled = true;
        }

        //Constructor sets initializer
        static DataBaseContext()
        {
            Database.SetInitializer<DataBaseContext>(new DataBaseInitializer());
        }

        /// <summary>
        /// Configur table to object mapping
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new DoctorModelConfig());
            modelBuilder.Configurations.Add(new PatientModelConfig());
            modelBuilder.Configurations.Add(new SpecializationModelConfig());
            modelBuilder.Configurations.Add(new RoomModelConfig());
        }

        //These properties represents Tables in Database.

        public DbSet<Patient> Patients { get; set; }        
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Room> Rooms { get; set; }        
    }
}