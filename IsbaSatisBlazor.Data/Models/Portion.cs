using IsbaSatisBlazor.Data.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Data.Models
{
    public class Portion:ModelBase
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal EkMalzemeCarpan { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product? Product { get; set; }
        public Guid UnitId { get; set; }
        public virtual Unit Unit { get; set; }

    }
}
