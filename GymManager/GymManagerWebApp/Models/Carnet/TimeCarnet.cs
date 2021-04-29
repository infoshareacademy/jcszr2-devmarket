using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Models
{
    public class TimeCarnet : Carnet
    {
        public DateTime UsedOn { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool IsExpired { get; set; }

        public TimeCarnet()
        { }

        public TimeCarnet(int id, string name, int periodLength, double price)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = periodLength;
        }
    }

}
