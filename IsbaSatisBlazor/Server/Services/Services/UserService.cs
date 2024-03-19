using AutoMapper;
using AutoMapper.QueryableExtensions;
using IsbaSatisBlazor.Data.Context;
using IsbaSatisBlazor.Data.Enums;
using IsbaSatisBlazor.Data.Models;
using IsbaSatisBlazor.Server.Services.Infrastruce;
using IsbaSatisBlazor.Shared.DTO;
using IsbaSatisBlazor.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IsbaSatisBlazor.Server.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly IsbaSatisDbContext context;
        private readonly IConfiguration configuration;
        public UserService(IMapper Mapper, IsbaSatisDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;
        }
        public async Task<UserDTO> CreateUser(UserDTO User)
        {
            
            var dbUser = await context.Users.Where(i => i.Id == User.Id).FirstOrDefaultAsync();

            if (dbUser != null)
                throw new Exception("Kullanıcı Zaten Mevcut");

           
            dbUser = mapper.Map<Data.Models.Users>(User);
            dbUser.CreateDate = DateTime.Now;
            await context.Users.AddAsync(dbUser);
            int result = await context.SaveChangesAsync();
            var value = Enum.GetValues(typeof(RoleType));
            foreach (RoleType item in value)
            {
                UserRole userRole = new UserRole();
                userRole.CreateDate = DateTime.Now;
                userRole.CreatedUser = User.CreatedUser;
                userRole.UserId = dbUser.Id;
                userRole.RoleType = item.ToString();
                await context.UserRoles.AddAsync(userRole);
                await context.SaveChangesAsync();
            }

            return mapper.Map<UserDTO>(dbUser);
        }

        public async Task<UserRoleDTO> CreateUserRole(UserRoleDTO UserRole)
        {
            var dbUserRole = await context.UserRoles.Where(i => i.RoleType == UserRole.RoleType && i.UserId==UserRole.UserId).FirstOrDefaultAsync();

            if (dbUserRole != null)
                throw new Exception("Rol Zaten Mevcut");


            dbUserRole = mapper.Map<Data.Models.UserRole>(UserRole);
            dbUserRole.CreateDate = DateTime.Now;
            await context.UserRoles.AddAsync(dbUserRole);
            int result = await context.SaveChangesAsync();

            return mapper.Map<UserRoleDTO>(dbUserRole);
        }

        public async Task<bool> DeleteUserById(Guid Id)
        {
            var dbUser = await context.Users.FirstOrDefaultAsync(i => i.Id == Id);

            if (dbUser == null)
                throw new Exception("Kullanıcı Bulunamadı");

            context.Users.Remove(dbUser);
            int result = await context.SaveChangesAsync();

            return result > 0;
        }
        public async Task<bool> DeleteUserRoleById(Guid Id)
        {
            var dbUserRoles = await context.UserRoles.Where(c => c.UserId == Id).ToListAsync() ;

            if (dbUserRoles == null)
                throw new Exception("Kullanıcıya Ait role bulunamadı Bulunamadı");

            context.UserRoles.RemoveRange(dbUserRoles);
            int result = await context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<UserDTO> GetUserById(Guid Id)
        {
            return await context.Users
                        .Where(i => i.Id == Id)
                        .ProjectTo<UserDTO>(mapper.ConfigurationProvider)
                        .FirstOrDefaultAsync();
        }

        public async Task<List<UserDTO>> GetUsers()
        {
            return await context.Users
                        .Where(i => i.IsActive)
                        .ProjectTo<UserDTO>(mapper.ConfigurationProvider)
                        .ToListAsync();
        }

        public async Task<List<UserRoleDTO>> GetUserRolesById(Guid Id)
        {
            var dbUserRole= await context.UserRoles.Include(c => c.Users)
                      .Where(c => c.UserId == Id)
                      .ProjectTo<UserRoleDTO>(mapper.ConfigurationProvider)
                      .ToListAsync();
            return dbUserRole;
        }

        public async Task<UserLoginResponseDTO> Login(string EMail, string Password)
        {
            // Veritabanı Kullanıcı Doğrulama İşlemleri Yapıldı.

            var encryptedPassword = PasswordEncrypter.Encrypt(Password);

            var dbUser = await context.Users.FirstOrDefaultAsync(i => i.EMailAddress == EMail && i.Password == encryptedPassword);

            if (dbUser == null)
                throw new Exception("Kullanıcı bulunamadı veya verilen bilgi yanlış");

            if (!dbUser.IsActive)
                throw new Exception("Kullanıcı durumu Pasif!");


            UserLoginResponseDTO result = new UserLoginResponseDTO();
            var dbUserRoles = await context.UserRoles.Where(c => c.UserId == dbUser.Id).ToListAsync();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(int.Parse(configuration["JwtExpiryInDays"].ToString()));
            var claims=new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, EMail));
            claims.Add(new Claim(ClaimTypes.Name, dbUser.FirstName + " " + dbUser.LastName));
            claims.Add(new Claim(ClaimTypes.UserData, dbUser.Id.ToString()));
            if (dbUserRoles != null)
            {
                foreach (var role in dbUserRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.RoleType.ToString()));
                }
            }
       
            //var claims = new[]
            //{
            //    new Claim(ClaimTypes.Email, EMail),
            //    new Claim(ClaimTypes.Name, dbUser.FirstName + " " + dbUser.LastName),
            //    new Claim(ClaimTypes.UserData, dbUser.Id.ToString())
            //};
           

            var token = new JwtSecurityToken(configuration["JwtIssuer"], configuration["JwtAudience"], claims.ToArray(), null, expiry, creds);
            result.ApiToken = new JwtSecurityTokenHandler().WriteToken(token);
            result.User = mapper.Map<UserDTO>(dbUser);

            return result;
        }

        public async Task<UserDTO> UpdateUser(UserDTO User)
        {
            var dbUser = await context.Users.Where(i => i.Id == User.Id).FirstOrDefaultAsync();

            if (dbUser == null)
                throw new Exception("Kullanıcı bulunamadı");


            mapper.Map(User, dbUser);

            int result = await context.SaveChangesAsync();

            return mapper.Map<UserDTO>(dbUser);
        }

        public async Task<UserRoleDTO> UpdateUserRole(UserRoleDTO UserRole)
        {
            var dbUserRole = await context.UserRoles.Where(i => i.Id == UserRole.Id).FirstOrDefaultAsync();

            if (dbUserRole == null)
                throw new Exception("Kullanıcı bulunamadı");


            mapper.Map(UserRole, dbUserRole);

            int result = await context.SaveChangesAsync();

            return mapper.Map<UserRoleDTO>(dbUserRole);
        }
    }
}
