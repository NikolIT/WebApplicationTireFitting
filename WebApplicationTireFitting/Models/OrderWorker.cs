using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplicationTireFitting.Models
{
    public partial class OrderWorker
    {
        public int IdOrder { get; set; }
        public int IdWorker { get; set; }

        public virtual Order IdOrderNavigation { get; set; }
        public virtual Worker IdWorkerNavigation { get; set; }
    }
}
