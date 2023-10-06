using IsbaSatisBlazor.Data.Enums;
using IsbaSatisBlazor.Data.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Data.Models
{
    public class ProductMotion:ModelBase
    {
        public ProductMotionType ProductMotionType { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SupplementaryMaterialPrice { get; set; }
        public decimal SupplementaryMaterialUnitPrice { get { return UnitPrice + SupplementaryMaterialPrice; } }
        public decimal Indirim { get; set; }
        public decimal ToplamTutar
        {
            get
            {
                return (Amount * SupplementaryMaterialUnitPrice) - ((Amount * SupplementaryMaterialUnitPrice) / 100 * Indirim);
            }
        }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public Guid PortionId { get; set; }
        public virtual Portion Portion { get; set; }
        public Guid AdisyonId { get; set; }
        public virtual Adisyon Adisyon { get; set; }
        public virtual ICollection<SupplementaryMaterialMotion> SupplementaryMaterialMotions { get; set; }
    }
}
