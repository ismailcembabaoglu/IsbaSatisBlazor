using IsbaSatisBlazor.Data.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Data.Models
{
    public class Product:ModelBase
    {
        public string Barcode{ get; set; }
        public string ProductName { get; set; }
        public string Photo { get; set; }
        public ICollection<Portion>? Portions { get; set; }
        public ICollection<SupplementaryMaterial>? SupplementaryMaterials { get; set; }
        public Guid ProductGroupId { get; set; }
        public virtual ProductGroup? ProductGroup { get; set; }
        public virtual ICollection<ProductMotion>? ProductMotions { get; set; }
        public virtual ICollection<ProductNote>? ProductNotes { get; set; }
    }
}
