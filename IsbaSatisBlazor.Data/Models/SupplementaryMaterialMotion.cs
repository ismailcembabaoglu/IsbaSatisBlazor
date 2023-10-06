using IsbaSatisBlazor.Data.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Data.Models
{
    public class SupplementaryMaterialMotion:ModelBase
    {
        public decimal Price { get; set; }
        public Guid SupplementaryMaterialId { get; set; }
        public virtual SupplementaryMaterial SupplementaryMaterial { get; set; }
        public Guid ProductMotionId { get; set; }
        public virtual ProductMotion ProductMotion { get; set; }
    }
}
