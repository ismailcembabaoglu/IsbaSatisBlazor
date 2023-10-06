using IsbaSatisBlazor.Data.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Data.Models
{
    public class PaymentMotion:ModelBase
    {
        public decimal Tutar { get; set; }
        public Guid PaymentTypeId { get; set; }
        public virtual PaymentType PaymentType { get; set; }
        public Guid AdisyonId { get; set; }
        public virtual Adisyon Adisyon { get; set; }
    }
}
