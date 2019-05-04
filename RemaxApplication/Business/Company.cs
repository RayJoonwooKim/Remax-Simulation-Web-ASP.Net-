using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemaxApplication.Business
{
    public class Company
    {
        private int companyID;
        private string name;
        private string location;
        private string email;
        private string phone;

        public Company()
        {

        }
        public Company(int companyID, string name, string location, string email, string phone)
        {
            this.companyID = companyID;
            this.name = name;
            this.location = location;
            this.email = email;
            this.phone = phone;
        }

        public int CompanyID { get => companyID; set => companyID = value; }
        public string Name { get => name; set => name = value; }
        public string Location { get => location; set => location = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
    }
}