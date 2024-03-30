using IsbaSatisBlazor.Shared.DTO;

namespace IsbaSatisBlazor.Server.Services.Infrastruce
{
    public interface IUserRoleService
    {

        public Task<UserRoleDTO> GetUserRoleById(Guid Id);

        public Task<List<UserRoleDTO>> GetUserRoles();
        public Task<List<UserRoleDTO>> GetUserRolesById(Guid Id);

        public Task<UserRoleDTO> CreateUserRole(UserRoleDTO UserRole);

        public Task<UserRoleDTO> UpdateUserRole(UserRoleDTO UserRole);

        public Task<bool> DeleteUserRoleId(Guid Id);
    }
}
