using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsPortal.Models
{
    public class Students
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public string Gender { get; set; }

        public bool Passport { get; set; }
    }
}