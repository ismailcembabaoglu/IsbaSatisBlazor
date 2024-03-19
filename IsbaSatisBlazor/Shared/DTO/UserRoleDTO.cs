using IsbaSatisBlazor.Data.Enums;
using IsbaSatisBlazor.Shared.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Shared.DTO
{
    public class UserRoleDTO:ModelBaseDTO
    {
        public Guid UserId { get; set; }
        public string RoleType { get; set; }
    }
}
