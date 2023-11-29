using IsbaSatisBlazor.Data.Enums;
using IsbaSatisBlazor.Shared.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Shared.DTO
{
    public class AdisyonDTO:ModelBaseDTO
    {
        public AdisyonStatus AdisyonDurum { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public Guid? DeskId { get; set; }
        public string? DeskName { get; set; }
        public string? GarsonName { get; set; }
        public string? CustomerName { get; set; }
        public Guid? GarsonId { get; set; }
        public Guid? CustomerId { get; set; }
    }
}
