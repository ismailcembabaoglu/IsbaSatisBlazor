using IsbaSatisBlazor.Data.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Data.Models
{
    public class DeskLocation:ModelBase
    {
        public string LocationName { get; set; }
        public ICollection<Desk>? Desks { get; set; }
    }
}
