using fitapp.Migrations;
using fitapp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace fitapp.DAL
{
    public class FitappDbInitializer : MigrateDatabaseToLatestVersion<FitappDbContext, Configuration>
    {
        //protected override void Seed(FitappDbContext context)
        //{
        //    SeedStoreData(context);
        //    base.Seed(context);
        //}

        public static void SeedDbData(FitappDbContext context)
        {
            var products = new List<Product>
            {
                new Product() { ProductId = 1, Name = "Jajo kurze", Kcal = 60.0, Proteins = 15.0, Carbohydrates = 1.3, Fats = 12.0 },
                new Product() { ProductId = 2, Name = "Jogurt", Kcal = 60.0, Proteins = 15.0, Carbohydrates = 7.2, Fats = 6.0 },
                new Product() { ProductId = 3, Name = "Makaron", Kcal = 60.0, Proteins = 1.0, Carbohydrates = 21.3, Fats = 12.0 },
                new Product() { ProductId = 4, Name = "Ryż", Kcal = 60.0, Proteins = 1.0, Carbohydrates = 20.5, Fats = 12.0 },
                new Product() { ProductId = 5, Name = "Ziemniak", Kcal = 60.0, Proteins = 1.0, Carbohydrates = 20.3, Fats = 1.0 },
                new Product() { ProductId = 6, Name = "Pomidor", Kcal = 60.0, Proteins = 2.0, Carbohydrates = 8.1, Fats = 1.0 },
                new Product() { ProductId = 7, Name = "Kalafior", Kcal = 60.0, Proteins = 5.0, Carbohydrates = 10.3, Fats = 2.0 },
                new Product() { ProductId = 8, Name = "Brokuł", Kcal = 60.0, Proteins = 5.0, Carbohydrates = 10.3, Fats = 2.0 },
                new Product() { ProductId = 9, Name = "Batonik", Kcal = 60.0, Proteins = 5.0, Carbohydrates = 19.3, Fats = 12.0 },
                new Product() { ProductId = 10, Name = "Mleko", Kcal = 10.0, Proteins = 5.0, Carbohydrates = 11.3, Fats = 1.0 },
                new Product() { ProductId = 11, Name = "Ser", Kcal = 55.0, Proteins = 7.8, Carbohydrates = 2.1, Fats = 11.0 },

            };

            products.ForEach(p => context.Products.AddOrUpdate(p));
            context.SaveChanges();
        }
    }
}