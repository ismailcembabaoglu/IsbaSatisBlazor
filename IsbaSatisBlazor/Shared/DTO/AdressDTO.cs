using IsbaSatisBlazor.Data.Enums;
using IsbaSatisBlazor.Shared.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Shared.DTO
{
    public class AdressDTO:ModelBaseDTO
    {
        public PhoneAdressType PhoneAdressType { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string District { get; set; }
        public string FullAddress { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
    }
}
