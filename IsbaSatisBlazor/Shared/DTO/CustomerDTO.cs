using IsbaSatisBlazor.Data.Enums;
using IsbaSatisBlazor.Shared.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Shared.DTO
{
    public class CustomerDTO:ModelBaseDTO
    {
        public string CustomerType { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string? Company { get; set; }
        public string CardNumber { get; set; }
    }
}
