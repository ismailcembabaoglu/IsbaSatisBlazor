using IsbaSatisBlazor.Data.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Shared.DTO
{
    public class PaymentMotionDTO:ModelBase
    {
        public decimal Price { get; set; }
        public Guid PaymentTypeId { get; set; }
        public string? PaymentName { get; set; }
        public Guid AdisyonId { get; set; }
      
    }
}
