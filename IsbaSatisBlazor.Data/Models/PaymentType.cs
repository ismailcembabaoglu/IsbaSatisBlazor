using IsbaSatisBlazor.Data.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Data.Models
{
    public class PaymentType:ModelBase
    {
        public string PaymentName { get; set; }
        public virtual ICollection<PaymentMotion> PaymentMotions { get; set; }

    }
}
