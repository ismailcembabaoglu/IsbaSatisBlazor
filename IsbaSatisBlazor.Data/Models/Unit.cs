using IsbaSatisBlazor.Data.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Data.Models
{
    public class Unit:ModelBase
    {
        public string GroupName { get; set; }
        public ICollection<Portion>? Portions { get; set; }
    }
}
