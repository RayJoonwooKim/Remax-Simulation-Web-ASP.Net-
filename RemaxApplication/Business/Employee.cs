using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemaxApplication.Business
{
    public class Employee
    {
        private int empID;
        private string name;
        private string title;
        private string email;
        private string phone;

        public Employee()
        {

        }
        public Employee(int empID, string name, string title, string email, string phone)
        {
            this.empID = empID;
            this.name = name;
            this.title = title;
            this.email = email;
            this.phone = phone;
        }

        public int EmpID { get => empID; set => empID = value; }
        public string Name { get => name; set => name = value; }
        public string Title { get => title; set => title = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
    }
}