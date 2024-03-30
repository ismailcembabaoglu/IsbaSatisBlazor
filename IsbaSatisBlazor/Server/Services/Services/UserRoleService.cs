using AutoMapper;
using AutoMapper.QueryableExtensions;
using IsbaSatisBlazor.Data.Context;
using IsbaSatisBlazor.Data.Models;
using IsbaSatisBlazor.Server.Services.Infrastruce;
using IsbaSatisBlazor.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace IsbaSatisBlazor.Server.Services.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IMapper mapper;
        private readonly IsbaSatisDbContext context;
        private readonly IConfiguration configuration;

        public UserRoleService(IMapper Mapper, IsbaSatisDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;
        }

        public async Task<UserRoleDTO> CreateUserRole(UserRoleDTO UserRole)
        {
            var dbUserRole = await context.UserRoles.Where(i => i.Id == UserRole.Id).FirstOrDefaultAsync();

            if (dbUserRole != null)
                throw new Exception("Kullanıcı Rolü Zaten Mevcut");


            dbUserRole = mapper.Map<Data.Models.UserRole>(UserRole);
            dbUserRole.CreateDate = DateTime.Now;
            await context.UserRoles.AddAsync(dbUserRole);
            int result = await context.SaveChangesAsync();

            return mapper.Map<UserRoleDTO>(dbUserRole);
        }

        public async Task<bool> DeleteUserRoleId(Guid Id)
        {
            var dbUserRole = await context.UserRoles.Where(i => i.Id == Id).FirstOrDefaultAsync();

            if (dbUserRole == null)
                throw new Exception("Kullanıcı Rolü Bulunamadı");
            context.UserRoles.Remove(dbUserRole);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<UserRoleDTO> GetUserRoleById(Guid Id)
        {
            return await context.UserRoles
                .Where(i => i.Id == Id).Include(c => c.Users)
                .ProjectTo<UserRoleDTO>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<List<UserRoleDTO>> GetUserRoles()
        {
            return await context.UserRoles.Include(c => c.Users)
                    .ProjectTo<UserRoleDTO>(mapper.ConfigurationProvider)
                    .ToListAsync();
        }

        public async Task<List<UserRoleDTO>> GetUserRolesById(Guid Id)
        {
            return await context.UserRoles.Include(c => c.Users)
                       .Where(c => c.UserId == Id)
                       .ProjectTo<UserRoleDTO>(mapper.ConfigurationProvider)
                       .ToListAsync();
        }

        public async Task<UserRoleDTO> UpdateUserRole(UserRoleDTO UserRole)
        {
            var dbUserRole = await context.UserRoles.Where(i => i.Id == UserRole.Id).FirstOrDefaultAsync();

            if (dbUserRole == null)
                throw new Exception("Kullanıcı Rolü bulunamadı");


            mapper.Map(UserRole, dbUserRole);

            int result = await context.SaveChangesAsync();

            return mapper.Map<UserRoleDTO>(dbUserRole);
        }
    }
}
