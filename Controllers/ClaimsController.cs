using ClaimSubmissionApi.Data.Dtos;
using ClaimSubmissionApi.Data.Enums;
using ClaimSubmissionApi.Services;
using ClaimSubmissionApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ClaimSubmissionApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ClaimsController : ControllerBase
    {

        private readonly ILogger<ClaimsController> _logger;
        private readonly IClaimsServices claimsServices;

        public ClaimsController(ILogger<ClaimsController> logger, IClaimsServices claimsServices)
        {
            _logger = logger;
            this.claimsServices = claimsServices;
        }

        [HttpGet(Name = "GetAllClaims")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> GetAllClaims()
        {
            var result = await claimsServices.GetAllClaims();
            return result is not null ? Ok(result) : NotFound("Empty result");
        }

        [HttpGet(Name = "GetClaim")]
        public async Task<IActionResult> GetClaim([FromQuery] int claimId)
        {
            var result = await claimsServices.GetClaim(claimId);
            return result is not null ? Ok(result) : NotFound("Empty result");
        }

        [HttpPost(Name = "MakeAClaim")]
        public async Task<IActionResult> MakeAClaim([FromBody] MakeClaimDto makeClaim)
        {
            if(ModelState.IsValid)
            {
                makeClaim.UserId = Convert.ToInt32(User.Identity.GetUserId());
                var result = await claimsServices.MakeAClaim(makeClaim);
                return result ? Ok(result) : BadRequest("an error has occured");
            }
            return BadRequest(ModelState);
        }

        [HttpPut(Name = "ReviewClaim")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> ReviewClaim([FromBody] ReviewClaimDto reviewClaim)
        {
            if (ModelState.IsValid)
            {
                reviewClaim.ReviewedBy = Convert.ToInt32(User.Identity.GetUserId());
                var result = await claimsServices.ReviewClaim(reviewClaim);
                return result ? Ok("Claims updated") : BadRequest("an error has occured");
            }
            return BadRequest(ModelState);
        }
    }
}