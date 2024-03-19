using IsbaSatisBlazor.Data.Enums;
using IsbaSatisBlazor.Data.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Data.Models
{
    public class UserRole:ModelBase
    {
        public Guid UserId { get; set; }
        public Users Users { get; set; }
        public string RoleType { get; set; }
    }
}
