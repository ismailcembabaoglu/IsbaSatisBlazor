using IsbaSatisBlazor.Data.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Data.Models
{
    public class Desk:ModelBase
    {
        public string Name { get; set; }
        public bool IsFull { get; set; }
        public int Capacity { get; set; }
        public Guid DeskLocationId { get; set; }
        public virtual DeskLocation? DeskLocation { get; set; }
        public ICollection<Adisyon>? Adisyons { get; set; }
    }
}
