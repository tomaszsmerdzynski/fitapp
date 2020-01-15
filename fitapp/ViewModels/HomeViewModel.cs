using fitapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace fitapp.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Product> Products { get; set; }
    }
}