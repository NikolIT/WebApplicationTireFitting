using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplicationTireFitting.Models
{
    public partial class Material
    {
        public Material()
        {
            MaterialsOrders = new HashSet<MaterialsOrder>();
        }

        public int IdMaterials { get; set; }
        public string NameMaterial { get; set; }
        public decimal Price { get; set; }
        public string PathMaterialsImg { get; set; }

        public virtual ICollection<MaterialsOrder> MaterialsOrders { get; set; }
    }
}
