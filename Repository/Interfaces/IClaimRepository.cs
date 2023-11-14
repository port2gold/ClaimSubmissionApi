using ClaimSubmissionApi.Data.Dtos;
using ClaimSubmissionApi.Model;

namespace ClaimSubmissionApi.Repository.Interfaces
{
    public interface IClaimRepository
    {
        Task<List<Claim>> GetClaimsForUser(int userId);
        Task<Claim?> GetClaim(long claimId);
        Task ReviewClaim(ReviewClaimDto reviewClaim);


    }
}
