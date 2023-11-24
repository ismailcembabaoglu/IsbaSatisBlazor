using IsbaSatisBlazor.Shared.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Shared.DTO
{
    public class LinkTestDTO:ModelBaseDTO
    {
        public string Magaza { get; set; }
        public string Link { get; set; }
        public int PageStart { get; set; }
        public int PageEnd { get; set; }
        public bool IsActive { get; set; }
    }
}
