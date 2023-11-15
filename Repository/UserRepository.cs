using ClaimSubmissionApi.Data;
using ClaimSubmissionApi.Data.Dtos;
using ClaimSubmissionApi.Model;
using ClaimSubmissionApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClaimSubmissionApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext ctx;

        public UserRepository(AppDbContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<bool> IsRegisteredUser(string email)
        {
            return ctx.Users.Any(x => x.Email == email);
        }

        public async Task LogIn()
        {

        }

    }
}
