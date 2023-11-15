using ClaimSubmissionApi.Data.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClaimSubmissionApi.Data.Dtos
{
    public class UserPayload
    {
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string? NationalId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string? FirstName { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string? LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string PolicyNumber { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string? Email { get; set; }
        public Gender Gender { get; set; }

        public string? Token { get; set; }
    }
}
