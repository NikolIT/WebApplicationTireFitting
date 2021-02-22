using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplicationTireFitting.Models
{
    public partial class Client
    {
        public Client()
        {
            Cars = new HashSet<Car>();
            Orders = new HashSet<Order>();
        }

        public int IdClient { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
