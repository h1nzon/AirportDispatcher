﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AirportDispatcher.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AirportDispatcherEntities : DbContext
    {
        public AirportDispatcherEntities()
            : base("name=AirportDispatcherEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Aircrafts> Aircrafts { get; set; }
        public virtual DbSet<Airports> Airports { get; set; }
        public virtual DbSet<BoardingPasses> BoardingPasses { get; set; }
        public virtual DbSet<Bookings> Bookings { get; set; }
        public virtual DbSet<EncryptionKeys> EncryptionKeys { get; set; }
        public virtual DbSet<Flights> Flights { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Seats> Seats { get; set; }
        public virtual DbSet<TicketFlights> TicketFlights { get; set; }
        public virtual DbSet<Tickets> Tickets { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
