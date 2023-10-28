using IsbaSatisBlazor.Shared.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Shared.DTO
{
    public class ProductNoteDTO:ModelBaseDTO
    {
        public Guid ProductId { get; set; }
        public string Note { get; set; }
    }
}
