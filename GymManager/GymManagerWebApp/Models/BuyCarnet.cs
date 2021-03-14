using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Models
{
    public class BuyCarnet
    {
        private List<Carnet> carnetListTypes = new List<Carnet>()
        {
            new Carnet(1, "Karnet jednorazowy"), new Carnet(2, "Karnet 1 tygodniowy"), new Carnet(3, "Karnet 1 miesięczny")
        };
        public string TicketType { get; set; }

        public List<Carnet> getCarnets()
        {
            return this.carnetListTypes;
        }
    }

    public class Carnet
    {
        public int Id;
        public string CarnetTypeName;

        public Carnet(int id, string carnetTypeName)
        {
            this.Id = id;
            this.CarnetTypeName = carnetTypeName;
        }

    }
}


