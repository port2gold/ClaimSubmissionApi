using ClaimSubmissionApi.Data.Dtos;
using ClaimSubmissionApi.Model;

namespace ClaimSubmissionApi.Services.Interfaces
{
    public interface IClaimsServices
    {
        Task<List<Claim>> GetAllClaims();
        Task<List<Claim>> GetAllClaimsForUser(int userId);
        Task<Claim> GetClaim(long claimId);
        Task<bool> ReviewClaim(ReviewClaimDto reviewClaim);

        Task<bool> MakeAClaim(MakeClaimDto makeClaim);
    }
}
