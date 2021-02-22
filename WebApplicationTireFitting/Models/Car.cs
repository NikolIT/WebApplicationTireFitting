using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplicationTireFitting.Models
{
    public partial class Car
    {
        public Car()
        {
            Orders = new HashSet<Order>();
        }

        public int IdCar { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public int IdClient { get; set; }
        public int IdTypeOfCar { get; set; }
        public string PathCarImg { get; set; }

        public virtual Client IdClientNavigation { get; set; }
        public virtual TypeOfCar IdTypeOfCarNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
