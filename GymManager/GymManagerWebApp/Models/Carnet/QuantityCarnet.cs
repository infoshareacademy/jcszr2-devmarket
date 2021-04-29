using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Models
{
    public class QuantityCarnet : Carnet
    {
        public int RemainQty { get; set; }
        public int UsedQty { get; set; }

        public QuantityCarnet()
        {

        }

        public QuantityCarnet(int id, string name, int quantity, double price)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }

    
}
