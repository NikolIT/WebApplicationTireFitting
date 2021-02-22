using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplicationTireFitting.Models
{
    public partial class Order
    {
        public Order()
        {
            MaterialsOrders = new HashSet<MaterialsOrder>();
            OrderWorkers = new HashSet<OrderWorker>();
            ServiceOrders = new HashSet<ServiceOrder>();
        }

        public int IdOrder { get; set; }
        public DateTime Date { get; set; }
        public int IdClient { get; set; }
        public int IdCar { get; set; }
        public decimal Price { get; set; }

        public virtual Car IdCarNavigation { get; set; }
        public virtual Client IdClientNavigation { get; set; }
        public virtual ICollection<MaterialsOrder> MaterialsOrders { get; set; }
        public virtual ICollection<OrderWorker> OrderWorkers { get; set; }
        public virtual ICollection<ServiceOrder> ServiceOrders { get; set; }
    }
}
