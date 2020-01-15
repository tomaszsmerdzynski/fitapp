﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace fitapp.Models
{
    public class UserData
    {
        [EmailAddress(ErrorMessage = "Błędny format adresu e-mail")]
        public string Email { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public int PhysicalActivity { get; set; }
    }
}