using ClaimSubmissionApi.Data.Dtos;
using ClaimSubmissionApi.Model;
using ClaimSubmissionApi.Repository.Interfaces;
using ClaimSubmissionApi.Services.Interfaces;

namespace ClaimSubmissionApi.Services
{
    public class ClaimsServices : IClaimsServices
    {
        private readonly IClaimRepository claims;

        public ClaimsServices(IClaimRepository claims)
        {
            this.claims = claims;
        }
        public async Task<List<Claim>> GetAllClaims()
        {
            return await claims.GetAllClaims();
        }

        public async Task<List<Claim>> GetAllClaimsForUser(int userId)
        {
            return await claims.GetClaimsForUser(userId);
        }

        public async Task<Claim?> GetClaim(long claimId)
        {
            return await claims.GetClaim(claimId);
        }

        public async Task<bool> MakeAClaim(MakeClaimDto makeClaim)
        {
            return await claims.MakeClaim(makeClaim);
        }

        public Task<bool> ReviewClaim(ReviewClaimDto reviewClaim)
        {
            return claims.ReviewClaim(reviewClaim);
        }
    }
}
