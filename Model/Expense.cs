using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClaimSubmissionApi.Model
{
    public class Expense
    {
        [Key]
        public long Id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string? ProcedureName { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string? MedicationName { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Amount { get; set; }
        [ForeignKey("ClaimId")]
        public long ClaimId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastUpdatedAt { get; set; }
        public int LastModifiedBy { get; set;}
    }
}
