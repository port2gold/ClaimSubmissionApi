using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClaimSubmissionApi.Data.Dtos
{
    public class SignInDto
    {
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
