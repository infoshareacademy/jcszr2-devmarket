using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp
{
    public class Carnet
    {
        public int Id { get; set; }
        public int CarnetTypeNumber { get; set; }
        public string CarnetCategory { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime PurchasedAt { get; set; }
        public string OwnerEmail { get; set; }
        public int Quantity { get; set; }
        public DateTime? UsedOn { get; set; }
        public DateTime? ExpireDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsExpired { get; set; }
        public int RemainQty { get; set; }

        public Carnet()
        {
        }

        public Carnet(int carnetTypeNumber, string carnetCategory, string name, double price, int quantity)
        {
            CarnetTypeNumber = carnetTypeNumber;
            CarnetCategory = carnetCategory;
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public Carnet(int carnetTypeNumber, string carnetCategory, string name, double price, int quantity, string ownerEmail, DateTime purchasedAt,
            int remainQty, bool isActive)
        {
            CarnetTypeNumber = carnetTypeNumber;
            CarnetCategory = carnetCategory;
            Name = name;
            Price = price;
            Quantity = quantity;
            OwnerEmail = ownerEmail;
            PurchasedAt = purchasedAt;
            RemainQty = remainQty;
            IsActive = isActive;
        }
    }
}
