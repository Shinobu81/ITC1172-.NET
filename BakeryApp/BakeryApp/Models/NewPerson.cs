using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BakeryApp;

namespace BakeryApp.Models
{
    public class NewPerson
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PersonPassword { get; set; }
    }
}