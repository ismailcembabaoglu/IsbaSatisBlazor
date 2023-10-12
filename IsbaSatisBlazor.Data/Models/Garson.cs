using IsbaSatisBlazor.Data.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Data.Models
{
    public class Garson:ModelBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<Adisyon> Adisyons { get; set; }
    }
}
