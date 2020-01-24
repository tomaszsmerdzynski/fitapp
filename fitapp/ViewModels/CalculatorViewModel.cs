using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace fitapp.ViewModels
{
    public class CalculatorViewModel
    {
        public int Age { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string PhysicalActivity { get; set; }
        public string Gender { get; set; }
        public double? BMI { get; set; }
        public double? BMR { get; set; }
        public double? CPM { get; set; }
    }
}