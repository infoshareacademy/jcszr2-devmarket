using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Models
{
    public class PurchasedCarnetsViewModel
    {
        public List<Carnet> TimeCarnets { get; set; }
        public List<Carnet> QuantityCarnets { get; set; }
    }
}
