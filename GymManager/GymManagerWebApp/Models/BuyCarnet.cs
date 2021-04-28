using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Models
{
    public class CarnetViewModel
    {
      public int Id { get; set; }
      public string Name { get; set; }

    }

    public class Carnet
    {
        public string Name { get; set; }
        public DateTime PurchasedAt { get; set; }
        public double Price { get; set; }
        public User Owner { get; set; }

    }

    public class CarnetTemporaryType : Carnet
    {
        public DateTime ExpireDate { get; set; }
    }

    public class CarnetQuantitativeType : Carnet
    {
        public int PurchasedAmount { get; set; }
        public int RemainAmount {get; set; }
        public int UsedAmount { get; set; }
    }



}


