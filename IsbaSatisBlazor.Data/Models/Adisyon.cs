using IsbaSatisBlazor.Data.Enums;
using IsbaSatisBlazor.Data.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Data.Models
{
    public class Adisyon:ModelBase
    {
        public AdisyonStatus AdisyonDurum { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public Guid? DeskId { get; set; }
        public virtual Desk Desk { get; set; }
        public Guid? GarsonId { get; set; }
        public virtual Garson Garson { get; set; }
        public Guid? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<ProductMotion> ProductMotions { get; set; }
        public virtual ICollection<PaymentMotion> PaymentMotions { get; set; }
    }
}
