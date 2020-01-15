using fitapp.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace fitapp.DAL
{
    public class FitappDbContext : IdentityDbContext<ApplicationUser>
    {
        //Konstruktor DbContext z Entity Framework - parametr to nazwa connection stringa
        public FitappDbContext() : base("FitappDbContext")
        {

        }

        static FitappDbContext()
        {
            Database.SetInitializer<FitappDbContext>(new FitappDbInitializer());
        }

        public static FitappDbContext Create()
        {
            return new FitappDbContext();
        }

        public DbSet<Product> Products { get; set; }
    }
}