using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Runtime.Serialization;
using PersianRug.Business.Entities;
using Core.Common.Contracts;

namespace PersianRug.Data
{
    public class PersianRugContext : DbContext
    {
        public PersianRugContext()
            : base("name=PersianRug")
        {
            Database.SetInitializer<PersianRugContext>(null);
        }

        public DbSet<Account> AccountSet { get; set; }

        public DbSet<TimeSlot> TimeSlotSet { get; set; }

        public DbSet<Appointment> AppointmentSet { get; set; }

        public DbSet<Reservation> ReservationSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Ignore<PropertyChangedEventHandler>();
            modelBuilder.Ignore<ExtensionDataObject>();
            modelBuilder.Ignore<IIdentifiableEntity>();

            modelBuilder.Entity<Account>().HasKey<int>(e => e.AccountId).Ignore(e => e.EntityId);
            modelBuilder.Entity<TimeSlot>().HasKey<int>(e => e.TimeSlotId).Ignore(e => e.EntityId);
            modelBuilder.Entity<Appointment>().HasKey<int>(e => e.AppointmentId).Ignore(e => e.EntityId);
            modelBuilder.Entity<Reservation>().HasKey<int>(e => e.ReservationId).Ignore(e => e.EntityId);
            modelBuilder.Entity<TimeSlot>().Ignore(e => e.CurrentlyBooked);
        }
    }
}
