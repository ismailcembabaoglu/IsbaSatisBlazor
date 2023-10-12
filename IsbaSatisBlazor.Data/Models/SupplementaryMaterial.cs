using IsbaSatisBlazor.Data.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Data.Models
{
    public class SupplementaryMaterial:ModelBase
    {
        public string SupplementaryMaterialName { get; set; }
        public decimal Price { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public ICollection<SupplementaryMaterialMotion> SupplementaryMaterialMotions { get; set; }
    }
}
