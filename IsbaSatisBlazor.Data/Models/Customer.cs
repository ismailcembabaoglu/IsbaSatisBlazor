using IsbaSatisBlazor.Data.Enums;
using IsbaSatisBlazor.Data.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Data.Models
{
    public class Customer:ModelBase
    {
        public CustomerType CustomerType { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string Company { get; set; }
        public string CardNumber { get; set; }
        public virtual ICollection<Phone> Telefonlar { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Adisyon> Adisyons { get; set; }
    }
}
