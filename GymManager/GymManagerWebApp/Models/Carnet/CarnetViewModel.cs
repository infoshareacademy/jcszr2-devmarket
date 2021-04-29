using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Models
{
    public class CarnetViewModel
    {
        private int monthDays = DateTime.DaysInMonth(DateTime.UtcNow.Year, DateTime.UtcNow.Month);

        public List<Carnet> CarnetList
        {
            get
            {
                return new List<Carnet>()
                {
                    new TimeCarnet(id: 1,name: "Karnet tygodniowy",periodLength: 7, price: 10.00),
                    new TimeCarnet(id: 2,name:"Karnet 30-dniowy", periodLength: 30, price: 30.00),
                    new TimeCarnet(id: 3,name:"Karnet 90-dniowy",periodLength: 90, price: 70.00),
                    new QuantityCarnet(id: 4,name:"Karnet- 1 wejście",quantity:1, price: 4.00),
                    new QuantityCarnet(id :5,name:"Karnet- 5 wejść", quantity:5,price: 8.00),
                    new QuantityCarnet(id: 6,name:"Karnet- 10 wejść",quantity:10, price: 15.00),
                    new QuantityCarnet(id: 7,name:"Karnet- 30 wejść",quantity:30, price: 30.00)
                };
            }
        }
    }
}
