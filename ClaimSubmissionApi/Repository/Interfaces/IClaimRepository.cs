using ClaimSubmissionApi.Data.Dtos;
using ClaimSubmissionApi.Model;

namespace ClaimSubmissionApi.Repository.Interfaces
{
    public interface IClaimRepository
    {
        Task<List<Claim>> GetClaimsForUser(int userId);
        Task<Claim?> GetClaim(long claimId);
        Task<bool> ReviewClaim(ReviewClaimDto reviewClaim);
        Task<List<Claim>> GetAllClaims();
        Task<bool> MakeClaim(MakeClaimDto makeClaim);




    }
}
