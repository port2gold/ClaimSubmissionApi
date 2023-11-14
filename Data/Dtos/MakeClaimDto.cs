
using ClaimSubmissionApi.Data.Enums;
using ClaimSubmissionApi.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClaimSubmissionApi.Data.Dtos
{
    public class MakeClaimDto
    {
        public MakeClaimDto()
        {
            
        }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(30)]
        public string? NationalId { get; set; }
        [Required]
        [ForeignKey("ApplicationUser")]
        public int UserId { get; set; }
        [Required]
        public List<Expense> Expenses { get; set; }
        [Required]
        public DateTime DateOfExpense { get; set; }

        [Required]
        public ClaimStatus ClaimStatus { get; set; } = ClaimStatus.SUBMITTED;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime LastUpdatedAt { get; set; }

        public int LastModifiedBy { get; set; }

    }
}
