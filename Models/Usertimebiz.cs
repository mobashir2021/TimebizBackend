using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobclubBackend.Models
{
    public class Usertimebiz
    {
        public int Userid { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobileno { get; set; }
        public string District { get; set; }
        public string Roles { get; set; }
        public string Companyname { get; set; }
        public string Companyid { get; set; }

        public string Address { get; set; }
    }
}