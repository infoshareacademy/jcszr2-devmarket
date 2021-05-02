using GymManagerWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp
{
    public class CarnetsOfferViewModel
    {
        public string TimeCarnetCategory { get { return "czasowy"; } }
        public string QuantityCarnetCategory { get { return "ilosciowy"; } }

        public List<Carnet> CarnetList
        {
            get
            {
                return new List<Carnet>()
                {
                    new Carnet(carnetTypeNumber: 1, carnetCategory: TimeCarnetCategory, name: "Karnet tygodniowy",quantity: 7, price: 10.00),
                    new Carnet(carnetTypeNumber: 2, carnetCategory: TimeCarnetCategory, name:"Karnet 30-dniowy", quantity: 30, price: 30.00),
                    new Carnet(carnetTypeNumber: 3, carnetCategory: TimeCarnetCategory, name:"Karnet 90-dniowy",quantity: 90, price: 70.00),
                    new Carnet(carnetTypeNumber: 4, carnetCategory: QuantityCarnetCategory,name:"Karnet- 1 wejście",quantity:1, price: 4.00),
                    new Carnet(carnetTypeNumber: 5, carnetCategory: QuantityCarnetCategory, name:"Karnet- 5 wejść", quantity:5,price: 8.00),
                    new Carnet(carnetTypeNumber: 6, carnetCategory: QuantityCarnetCategory, name:"Karnet- 10 wejść",quantity:10, price: 15.00),
                    new Carnet(carnetTypeNumber: 7, carnetCategory: QuantityCarnetCategory, name:"Karnet- 30 wejść",quantity:30, price: 30.00)
                };
            }
        }
    }
}
