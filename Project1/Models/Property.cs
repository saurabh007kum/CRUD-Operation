using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class Property
    {
        public int action { get; set; }
        public int User_id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public string srno { get; set; }
        public string picture { get; set; }
        //public HttpPostedFileBase Image { get; set; }
        public string Status { get; set; }
        public DataTable dt { get; set; }
    }
}