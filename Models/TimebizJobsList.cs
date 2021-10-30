using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobclubBackend.Models
{
    public class TimebizJobsList
    {
        public int Jobid { get; set; }
        public string JobTitle { get; set; }
        public string Description { get; set; }
        public string Designation { get; set; }
        public string Companyid { get; set; }
        public string Salary { get; set; }

        public string Vacancies { get; set; }

        public string Experience { get; set; }
        public string Companyname { get; set; }
        public string District { get; set; }
        public string Category { get; set; }

        public string Skills { get; set; }
        public string PostedOn { get; set; }
    }
}