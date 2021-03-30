using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryWebSiteProject.Models
{
    public class ShiftsToEmp
    {
        public string FullName { get; set; }
        public DateTime shifts { get; set; }
        public int empID { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public string Dep { get; set; }
    }
}