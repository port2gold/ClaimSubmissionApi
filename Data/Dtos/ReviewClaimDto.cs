using ClaimSubmissionApi.Data.Enums;

namespace ClaimSubmissionApi.Data.Dtos
{
    public class ReviewClaimDto
    {
        public int ClaimId { get; set; }
        public ClaimStatus Status { get; set; }
        public int ReviewedBy { get; set; }

    }
}
