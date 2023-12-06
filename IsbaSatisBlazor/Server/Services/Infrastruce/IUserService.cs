using IsbaSatisBlazor.Shared.DTO;

namespace IsbaSatisBlazor.Server.Services.Infrastruce
{
    public interface IUserService
    {
        public Task<UserDTO> GetUserById(Guid Id);

        public Task<List<UserDTO>> GetUsers();

        public Task<UserDTO> CreateUser(UserDTO User);
        public Task<UserRoleDTO> CreateUserRole(UserRoleDTO UserRole);

        public Task<UserDTO> UpdateUser(UserDTO User);
        public Task<UserRoleDTO> UpdateUserRole(UserRoleDTO UserRole);

        public Task<bool> DeleteUserById(Guid Id);

        public Task<UserLoginResponseDTO> Login(string EMail, string Password);
    }
}
