using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class OMAContext : DbContext
    {

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Addresses { get; set; }
        
        public OMAContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Customer>().HasData(
                new Customer{
                    Id =1,
                    FirstName = "James",
                    LastName="Bond",
                    ContactNumber="123456789",
                    IsDeleted=false,
                    Email = "jamesbond@hermajesty.com"
                },
                new Customer{
                    Id =2,
                    FirstName = "Monty",
                    LastName="Python",
                    ContactNumber="9865741",
                    IsDeleted=false,
                    Email = "monty@hermajesty.com"
                }
            );

            modelBuilder.Entity<Address>().HasData(
                new Address{
                    Id =1,
                    CustomerId =1,
                    AddressLine1 = "Someplace1",
                    AddressLine2 = "Someplace2",
                    City = "Melbourne",
                    State = "Victoria",
                    Country = "AU"
                },
                new Address{
                    Id =2,
                    CustomerId =2,
                    AddressLine1 = "NewPlace1",
                    AddressLine2 = "NewPlace2",
                    City = "Melbourne",
                    State = "Victoria",
                    Country = "AU"
                }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order{
                    Id =1,
                    CustomerId = 1,
                    OrderDate = new DateTime(2024,01,02),
                    Description = "New Item",
                    TotalAmount =500,
                    DepositAmount =10,
                    IsDelivery =true,
                    Status = Status.Pending,
                    OtherNotes = "Something new",
                    IsDeleted =false
                },
                new Order{
                    Id =2,
                    CustomerId = 2,
                    OrderDate = DateTime.Now,
                    Description = "Poori",
                    TotalAmount =200,
                    DepositAmount =20,
                    IsDelivery =false,
                    Status = Status.Completed,
                    OtherNotes = "Masalar added",
                    IsDeleted =false
                }
            );
        }
    }
}