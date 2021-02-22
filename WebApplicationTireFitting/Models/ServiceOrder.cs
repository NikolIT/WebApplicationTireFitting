using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplicationTireFitting.Models
{
    public partial class ServiceOrder
    {
        public int IdService { get; set; }
        public int IdOrder { get; set; }

        public virtual Order IdOrderNavigation { get; set; }
        public virtual Service IdServiceNavigation { get; set; }
    }
}
