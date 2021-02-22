using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplicationTireFitting.Models
{
    public partial class Service
    {
        public Service()
        {
            ServiceOrders = new HashSet<ServiceOrder>();
        }

        public int IdService { get; set; }
        public string ServiceName { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<ServiceOrder> ServiceOrders { get; set; }
    }
}
