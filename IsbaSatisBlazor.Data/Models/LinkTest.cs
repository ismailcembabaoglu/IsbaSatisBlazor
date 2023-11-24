using IsbaSatisBlazor.Data.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Data.Models
{
    public class LinkTest:ModelBase
    {
        public string Magaza { get; set; }
        public string Link { get; set; }
        public int PageStart {  get; set; }
        public int PageEnd { get; set; }
        public bool IsActive { get; set; }
    }
}
