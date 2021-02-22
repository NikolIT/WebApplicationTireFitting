using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplicationTireFitting.Models
{
    public partial class Worker
    {
        public Worker()
        {
            OrderWorkers = new HashSet<OrderWorker>();
        }

        public int IdWorker { get; set; }
        public int IdPosition { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int Rate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PathWorkerImg { get; set; }

        public virtual Position IdPositionNavigation { get; set; }
        public virtual ICollection<OrderWorker> OrderWorkers { get; set; }
    }
}
