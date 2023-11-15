using ClaimSubmissionApi.Data.Dtos;
using ClaimSubmissionApi.Data.Enums;
using ClaimSubmissionApi.Model;
using ClaimSubmissionApi.Repository;
using ClaimSubmissionApi.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace ClaimSubmissionApi.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserRepository user;
        private readonly IConfiguration config;

        public AuthServices(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, UserRepository user, IConfiguration config)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.user = user;
            this.config = config;
        }

        public async Task<bool> CreateUserPolicyHolder(CreateUserDto newUser)
        {
            if (await user.IsRegisteredUser(newUser.Email)) return false;

            ApplicationUser applicationUser = ConvertSignUpDto(newUser);

            bool registrationSuccessful  = await RegisterUser(applicationUser, newUser.Password);

            if (!registrationSuccessful) return false;

            bool rolesAdded = await AddUserToRole(applicationUser, new List<Roles> { Roles.POLICYHOLDER });
            if (!rolesAdded) return false;

            return true;
        }
        public async Task<bool> CreateUserAdmin(CreateUserDto newUser)
        {
            if (await user.IsRegisteredUser(newUser.Email)) return false;

            ApplicationUser applicationUser = ConvertSignUpDto(newUser);

            bool registrationSuccessful = await RegisterUser(applicationUser, newUser.Password);

            if (!registrationSuccessful) return false;

            bool rolesAdded = await AddUserToRole(applicationUser, new List<Roles> { Roles.ADMIN });
            if (!rolesAdded) return false;

            return true;
        }

        public async Task<UserPayload> SignIn(SignInDto signIn)
        {
            var result = await signInManager.PasswordSignInAsync(signIn.Email, signIn.Password, false, false);
            if(result.Succeeded)
            {
                return await GetUserPayload(signIn.Email);
            }
            return null;
        }
        private async Task<bool> RegisterUser(ApplicationUser user, string password)
        {
            var result = await userManager.CreateAsync(user, password);

            return result.Succeeded;
        }

        private async Task<bool> AddUserToRole(ApplicationUser user, List<Roles> roles)
        {
            if (!roles.Any()) return false;
            var result = await userManager.AddToRolesAsync(user, roles.Select(x => x.ToString()).ToList());
            return result.Succeeded;
        }

        private async Task<UserPayload> GetUserPayload(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user is null) return null;

            var roles = await userManager.GetRolesAsync(user);

            return new UserPayload
            {
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                Gender = user.Gender,
                FirstName = user.FirstName,
                LastName = user.LastName,
                NationalId = user.NationalId,
                PolicyNumber = user.PolicyNumber,
                Token = JwtTokenService.GetToken(user, config.GetSection("Secrets:Key").Value,  roles.Select(x => x))
            };
        }

        private ApplicationUser ConvertSignUpDto(CreateUserDto newUser)
        {
            return  new ApplicationUser
            {
                Email = newUser.Email,
                UserName = newUser.Email,
                Gender = newUser.Gender,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                PolicyNumber = newUser.PolicyNumber,
                DateOfBirth = newUser.DateOfBirth,
                CreatedAt = DateTime.UtcNow,
                LastUpdatedAt = DateTime.UtcNow,

            };
        }

       
    }
}
