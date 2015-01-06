using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RAKHospitalAdmin.Models
{
    public class DataBaseInitializer : CreateDatabaseIfNotExists<DataBaseContext>
    {
        protected override void Seed(DataBaseContext context)
        {
            Room rA = new Room();
            rA.Name = "Category A";
            rA.Cost = 1200;
            context.Rooms.Add(rA);

            Room rB = new Room();
            rB.Name = "Category B";
            rB.Cost = 500;
            context.Rooms.Add(rB);

            Specialization sp = new Specialization();
            sp.Name = "ENT";
            context.Specializations.Add(sp);

            sp = new Specialization();
            sp.Name = "Cardiology";
            context.Specializations.Add(sp);

            sp = new Specialization();
            sp.Name = "Neurology";
            context.Specializations.Add(sp);

            sp = new Specialization();
            sp.Name = "Pathology";
            context.Specializations.Add(sp);

            context.SaveChanges();
        }
    }
}