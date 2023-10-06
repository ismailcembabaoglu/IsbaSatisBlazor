using IsbaSatisBlazor.Data.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Data.Models
{
    public class ProductNote:ModelBase
    {
        public Guid ProductId { get; set; }
        public string Note { get; set; }
        public virtual Product? Product { get; set; }
    }
}
