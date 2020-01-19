using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace fitapp.Models
{
    public class UserData
    {
        // MOZNA USUNAC CHYBA
        [EmailAddress(ErrorMessage = "Błędny format adresu e-mail")]
        public string Email { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string PhysicalActivity { get; set; }
        public string Gender { get; set; }
        public double BMI { get; set; }
        public double BMR { get; set; }
        public double CPM { get; set; }
    }
}