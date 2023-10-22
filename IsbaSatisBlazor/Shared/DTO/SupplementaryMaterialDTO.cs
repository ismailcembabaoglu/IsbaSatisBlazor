using IsbaSatisBlazor.Shared.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Shared.DTO
{
    public class SupplementaryMaterialDTO:ModelBaseDTO
    {
        public string SupplementaryMaterialName { get; set; }
        public decimal Price { get; set; }
        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }
    }
}
