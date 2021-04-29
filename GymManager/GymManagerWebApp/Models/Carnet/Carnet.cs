using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Models
{
    public class Carnet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime PurchasedAt { get; set; }
        public string OwnerEmail { get; set; }
        public int Quantity { get; set; }

        public Carnet()
        { }

        public Carnet(int id, string name, double price, int quantity)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        
    }
}
