using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RMS2.Models
{
    public class DBModel : DbContext
    {
        public DBModel() : base("Niroshan")
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }
        public DbSet<CustomerRegistration> CustomerRegistrations { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetailss { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

    }
}