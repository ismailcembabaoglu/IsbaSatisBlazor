using IsbaSatisBlazor.Shared.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Shared.DTO
{
    public class PortionDTO:ModelBaseDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal SupplementaryMaterialMultiplier { get; set; }
        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }
        public Guid UnitId { get; set; }
       
        public string? UnitGroupName { get; set; }

    }
}
