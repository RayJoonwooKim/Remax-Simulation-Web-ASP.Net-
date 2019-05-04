using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemaxApplication.Business
{
    public class Client
    {
        private int clientID;
        private string name;
        private string email;
        private string phone;

        public Client()
        {

        }
        
        public Client(int clientID, string name, string email, string phone)
        {
            this.clientID = clientID;
            this.name = name;
            this.email = email;
            this.phone = phone;
        }

        public int ClientID { get => clientID; set => clientID = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
    }
}