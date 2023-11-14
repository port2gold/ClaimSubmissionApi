using ClaimSubmissionApi.Data;
using ClaimSubmissionApi.Data.Dtos;
using ClaimSubmissionApi.Model;
using ClaimSubmissionApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClaimSubmissionApi.Repository
{
    public class ClaimsRepository : IClaimRepository
    {
        private readonly AppDbContext ctx;

        public ClaimsRepository(AppDbContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<List<Claim>> GetClaimsForUser(int userId)
        {
            return await ctx.Claims.Where(x => x.UserId == userId).ToListAsync();
        }
        public async Task<Claim?> GetClaim(long claimId)
        {
            return await ctx.Claims.FirstOrDefaultAsync(x => x.ClaimId == claimId);
        }
        public async Task ReviewClaim(ReviewClaimDto reviewClaim)
        {
            var claim = await ctx.Claims.FirstOrDefaultAsync(x => x.ClaimId == reviewClaim.ClaimId);

            if(claim is null)
            {
                return;
            }
            claim.ClaimStatus = reviewClaim.Status;
            claim.LastModifiedBy = reviewClaim.ReviewedBy;
            claim.LastUpdatedAt = DateTime.Now;

            ctx.Update(claim);
            ctx.SaveChanges();
        }
        public async Task MakeClaim(MakeClaimDto makeClaim)
        {
            Claim claim = new Claim
            {
                NationalId = makeClaim.NationalId,
                LastUpdatedAt = DateTime.Now,
                LastModifiedBy = makeClaim.UserId,
                DateOfExpense = makeClaim.DateOfExpense,
                Expenses = makeClaim.Expenses,
                UserId = makeClaim.UserId,
            };
            await ctx.Claims.AddAsync(claim);
            ctx.SaveChanges();
        }
    }
}
