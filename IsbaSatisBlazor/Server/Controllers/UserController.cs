using IsbaSatisBlazor.Server.Services.Extensions;
using IsbaSatisBlazor.Server.Services.Infrastruce;
using IsbaSatisBlazor.Server.Services.Services;
using IsbaSatisBlazor.Shared.DTO;
using IsbaSatisBlazor.Shared.Extensions;
using IsbaSatisBlazor.Shared.ResponseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsbaSatisBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles =RoleExtension.User)]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService UserService)
        {
            userService = UserService;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ServiceResponse<UserLoginResponseDTO>> Login(UserLoginRequestDTO UserRequest)
        {
            return new ServiceResponse<UserLoginResponseDTO>()
            {
                Value = await userService.Login(UserRequest.Email, UserRequest.Password)
            };
        }

        [HttpGet("Users")]
        public async Task<ServiceResponse<List<UserDTO>>> GetUsers()
        {
            return new ServiceResponse<List<UserDTO>>()
            {
                Value = await userService.GetUsers()
            };
        }
        [HttpGet("UserRolesById/{Id}")]
        [AllowAnonymous]
        public async Task<ServiceResponse<List<UserRoleDTO>>> GetUserRolesById(Guid Id)
        {
            return new ServiceResponse<List<UserRoleDTO>>()
            {
                Value = await userService.GetUserRolesById(Id)
            };
        }

        [HttpPost("Create")]
        public async Task<ServiceResponse<UserDTO>> CreateUser([FromBody] UserDTO User)
        {
            return new ServiceResponse<UserDTO>()
            {
                Value = await userService.CreateUser(User)
            };
        }
        [HttpPost("UserRoleCreate")]
        public async Task<ServiceResponse<UserRoleDTO>> CreateUserRole([FromBody] UserRoleDTO UserRole)
        {
            return new ServiceResponse<UserRoleDTO>()
            {
                Value = await userService.CreateUserRole(UserRole)
            };
        }

        [HttpPost("Update")]
        public async Task<ServiceResponse<UserDTO>> UpdateUser([FromBody] UserDTO User)
        {
            return new ServiceResponse<UserDTO>()
            {
                Value = await userService.UpdateUser(User)
            };
        }
        [HttpPost("UserRole/Update")]
        public async Task<ServiceResponse<UserRoleDTO>> UpdateUserRole([FromBody] UserRoleDTO UserRole)
        {
            return new ServiceResponse<UserRoleDTO>()
            {
                Value = await userService.UpdateUserRole(UserRole)
            };
        }

        [HttpGet("UserById/{Id}")]
       
        public async Task<ServiceResponse<UserDTO>> GetUserById(Guid Id)
        {
            return new ServiceResponse<UserDTO>()
            {
                Value = await userService.GetUserById(Id)
            };
        }


        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteUser([FromBody] Guid id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await userService.DeleteUserById(id)
            };
        }
        [HttpPost("UserRole/Delete")]
      
        public async Task<ServiceResponse<bool>> DeleteUserRole([FromBody] Guid id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await userService.DeleteUserRoleById(id)
            };
        }
    }
}
