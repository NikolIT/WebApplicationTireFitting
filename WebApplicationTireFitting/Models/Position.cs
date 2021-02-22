using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplicationTireFitting.Models
{
    public partial class Position
    {
        public Position()
        {
            Workers = new HashSet<Worker>();
        }

        public int IdPosition { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Worker> Workers { get; set; }
    }
}
