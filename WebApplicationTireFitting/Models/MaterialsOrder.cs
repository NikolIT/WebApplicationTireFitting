using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplicationTireFitting.Models
{
    public partial class MaterialsOrder
    {
        public int IdOrder { get; set; }
        public int IdMaterials { get; set; }

        public virtual Material IdMaterialsNavigation { get; set; }
        public virtual Order IdOrderNavigation { get; set; }
    }
}
