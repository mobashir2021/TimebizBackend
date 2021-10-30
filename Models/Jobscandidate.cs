using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobclubBackend.Models
{
    public class Jobscandidate
    {
        public int JobId { get; set; }

        public int Userid { get; set; }

        public string Name { get; set; }

        public string Qualification { get; set; }
        public string Skills { get; set; }

        public string Experience { get; set; }

        public string Resumepath { get; set; }
        public DateTime AppliedDate { get; set; }
        public string Designation { get; set; }
    }
}