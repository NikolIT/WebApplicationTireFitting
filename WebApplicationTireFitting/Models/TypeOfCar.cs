using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplicationTireFitting.Models
{
    public partial class TypeOfCar
    {
        public TypeOfCar()
        {
            Cars = new HashSet<Car>();
        }

        public int IdTypeOfCar { get; set; }
        public string TypeOfCar1 { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
