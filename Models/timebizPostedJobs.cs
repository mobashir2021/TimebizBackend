using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobclubBackend.Models
{
    public class timebizPostedJobs
    {
        public int JobId { get; set; }
        public string JobTitle { get; set; }

        public int Companyid { get; set; }

        public string Description { get; set; }

        public string Designation { get; set; }

        public int Vacancy { get; set; }
    }
}