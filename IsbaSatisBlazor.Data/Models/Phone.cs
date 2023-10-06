using IsbaSatisBlazor.Data.Enums;
using IsbaSatisBlazor.Data.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Data.Models
{
    public class Phone:ModelBase
    {
        public PhoneAdressType PhoneAdressType { get; set; }
        public string PhoneNumber { get; set; }
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
