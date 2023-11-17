using ClaimSubmissionApi.Data.Dtos;
using ClaimSubmissionApi.Model;

namespace ClaimSubmissionApi.Services.Interfaces
{
    public interface IAuthServices
    {
        Task<bool> CreateUserPolicyHolder(CreateUserDto newUser);
        Task<bool> CreateUserAdmin(CreateUserDto newUser);
        Task<UserPayload> SignIn(SignInDto signIn);
    }
}
