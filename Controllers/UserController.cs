using ClaimSubmissionApi.Data.Dtos;
using ClaimSubmissionApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClaimSubmissionApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IAuthServices authServices;

        public UserController(IAuthServices authServices)
        {
            this.authServices = authServices;
        }

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
