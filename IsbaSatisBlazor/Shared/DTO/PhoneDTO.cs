using IsbaSatisBlazor.Data.Enums;
using IsbaSatisBlazor.Shared.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Shared.DTO
{
    public class PhoneDTO : ModelBaseDTO
    {
        public PhoneAdressType PhoneAdressType { get; set; }
        public string PhoneNumber { get; set; }
        public Guid CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerSurname { get; set; }
    }
}
