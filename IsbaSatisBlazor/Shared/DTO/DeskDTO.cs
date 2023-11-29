using IsbaSatisBlazor.Shared.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Shared.DTO
{
    public class DeskDTO:ModelBaseDTO
    {
        public string Name { get; set; }
        public bool IsFull { get; set; }
        public int Capacity { get; set; }
        public Guid DeskLocationId { get; set; }
        public string DeskLocationName { get; set; }
    }
}
