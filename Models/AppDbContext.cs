using BusBookingSystem.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusBookingSystem.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Calling super class method
            base.OnModelCreating(modelBuilder);

            // Adding Discriminator in the ApplicationUser table
            // Declaring UserType as Discriminator
            modelBuilder.Entity<ApplicationUser>()
                .HasDiscriminator<string>("UserType")
                .HasValue<Passenger>(AppConstant.PASSENGER)
                .HasValue<BusOperator>(AppConstant.BUS_OPERATOR)
                .HasValue<Admin>(AppConstant.ADMIN);

            // Creating CompositeKey for Transaction
            // TicketId and PassengerInfoId as composite key
            modelBuilder.Entity<Transaction>()
              .HasKey(t => new { t.TicketId, t.PassengerInfoId});
        }

        // Entities
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Passenger> Passenger { get; set; }
        public DbSet<BusOperator> BusOperator { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<PassengerInfo> PassengerInfo { get; set; }
        public DbSet<Bus> Bus { get; set; }
        public DbSet<BusRoute> BusRoute { get; set; }
        public DbSet<Seat> Seat { get; set; }        
    }
}
