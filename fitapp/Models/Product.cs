using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace fitapp.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        
        [StringLength(50)]
        public string Name { get; set; }

        public double Kcal { get; set; }

        public double Proteins { get; set; }

        public double Carbohydrates { get; set; }

        public double Fats { get; set; }
    }
}