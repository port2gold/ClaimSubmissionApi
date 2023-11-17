using ClaimSubmissionApi.Data.Dtos;
using ClaimSubmissionApi.Data.Enums;
using ClaimSubmissionApi.Model;
using ClaimSubmissionApi.Services;
using ClaimSubmissionApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClaimSubmissionApi.Controllers
{
    [ApiController]
    [Route("api/v1[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ClaimsController : ControllerBase
    {

        private readonly IClaimsServices claimsServices;

        public ClaimsController(IClaimsServices claimsServices)
        {
            this.claimsServices = claimsServices;
        }
        /// <summary>
        /// Retrieves all claims can only be used by ADMIN
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Claims retrieved</response>
        /// <response code="400">missing/invalid values</response>
        /// <response code="500">Oops! Internal server error</response>
        [ProducesResponseType(typeof(List<Claim>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        [HttpGet(Name = "GetAllClaims")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> GetAllClaims()
        {
            var result = await claimsServices.GetAllClaims();
            return result is not null ? Ok(result) : NotFound("Empty result");
        }

        /// <summary>
        /// Retrieves a specific Claim by unique id
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Claim retrieved</response>
        /// <response code="400">Product has missing/invalid values</response>
        /// <response code="500">Oops! Internal server error</response>
        [ProducesResponseType(typeof(Claim), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        [HttpGet(Name = "GetClaim")]
        public async Task<IActionResult> GetClaim([FromQuery] int claimId)
        {
            var result = await claimsServices.GetClaim(claimId);
            return result is not null ? Ok(result) : NotFound("Empty result");
        }

        /// <summary>
        /// Add claims can only be used by ADMIN
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Claims retrieved</response>
        /// <response code="400">missing/invalid values</response>
        /// <response code="500">Oops! Internal server error</response>
        [ProducesResponseType(typeof(List<Claim>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        [HttpPost(Name = "MakeAClaim")]
        public async Task<IActionResult> MakeAClaim([FromBody] MakeClaimDto makeClaim)
        {
            if(ModelState.IsValid)
            {
                var result = await claimsServices.MakeAClaim(makeClaim);
                return result ? Ok(result) : BadRequest("an error has occured");
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Review claims can only be used by ADMIN
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Claims updateed successfully</response>
        /// <response code="400">missing/invalid values</response>
        /// <response code="500">Oops! Internal server error</response>
        [ProducesResponseType(typeof(List<Claim>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        [HttpPut(Name = "ReviewClaim")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> ReviewClaim([FromBody] ReviewClaimDto reviewClaim)
        {
            if (ModelState.IsValid)
            {
                var result = await claimsServices.ReviewClaim(reviewClaim);
                return result ? Ok("Claims updated") : BadRequest("an error has occured");
            }
            return BadRequest(ModelState);
        }
    }
}