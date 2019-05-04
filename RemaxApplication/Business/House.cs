using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemaxApplication.Business
{
    public class House
    {
        private int houseID;
        private string type;
        private string address;
        private double price;
        private int room;
        private int bathroom;
        private string description;
        private string contract;
        private int yearBuilt;

        public House()
        {

        }
        
        public House(int houseID, string type, string address, double price, int room, int bathroom, string description, string contract, int yearBuilt)
        {
            this.houseID = houseID;
            this.type = type;
            this.address = address;
            this.price = price;
            this.room = room;
            this.bathroom = bathroom;
            this.description = description;
            this.contract = contract;
            this.yearBuilt = yearBuilt;
        }

        public int HouseID { get => houseID; set => houseID = value; }
        public string Type { get => type; set => type = value; }
        public string Address { get => address; set => address = value; }
        public double Price { get => price; set => price = value; }
        public int Room { get => room; set => room = value; }
        public int Bathroom { get => bathroom; set => bathroom = value; }
        public string Description { get => description; set => description = value; }
        public string Contract { get => contract; set => contract = value; }
        public int YearBuilt { get => yearBuilt; set => yearBuilt = value; }
    }
}