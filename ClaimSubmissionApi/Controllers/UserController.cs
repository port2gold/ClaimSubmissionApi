using ClaimSubmissionApi.Data.Dtos;
using ClaimSubmissionApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClaimSubmissionApi.Controllers
{
    [ApiController]
    [Route("api/v1[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IAuthServices authServices;

        public UserController(IAuthServices authServices)
        {
            this.authServices = authServices;
        }

        /// <summary>
        /// Registrer Policy Holder user
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">User created</response>
        /// <response code="400">Product has missing/invalid values</response>
        /// <response code="500">Oops! Internal server error</response>
        [ProducesResponseType(typeof(ActionResult), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        [HttpPost("RegisterUserPolicyHolder")]
        public async Task<IActionResult> RegisterUserPolicyHolder(CreateUserDto newUser)
        {
            if(ModelState.IsValid)
            {
                var result = await authServices.CreateUserPolicyHolder(newUser);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }


        /// <summary>
        /// Register an Admin user
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">User created</response>
        /// <response code="400">missing/invalid values</response>
        /// <response code="500">Oops! Internal server error</response>
        [ProducesResponseType(typeof(ActionResult), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        [HttpPost("RegisterAdminUser")]
        public async Task<IActionResult> RegisterAdminUser(CreateUserDto newUser)
        {
            if (ModelState.IsValid)
            {
                var result = await authServices.CreateUserAdmin(newUser);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Sign in User
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Sign in successful</response>
        /// <response code="400">missing/invalid values</response>
        /// <response code="500">Oops! Internal server error</response>
        [ProducesResponseType(typeof(UserPayload), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInDto signIn)
        {
            if (ModelState.IsValid)
            {
                var result = await authServices.SignIn(signIn);
                return result is not null ? Ok(result) : BadRequest("Sign in error");
            }
            return BadRequest(ModelState);
        }
    }
}
