using FluentValidation;
using IsbaSatisBlazor.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Shared.Validators
{
    public class UserRoleValidator:AbstractValidator<UserRoleDTO>
    {
        public UserRoleValidator()
        {
           
        }
    }
}
