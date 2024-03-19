using IsbaSatisBlazor.Shared.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Shared.DTO
{
    public class SupplementaryMaterialMotionDTO:ModelBaseDTO
    {
        public decimal Price { get; set; }
        public Guid SupplementaryMaterialId { get; set; }
        public Guid ProductMotionId { get; set; }
        public string? SupplementaryMaterialName { get; set; }
    }
}
