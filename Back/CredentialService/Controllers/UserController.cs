using Api.Services.Interfaces;
using Api.Services.Models.RequestModels;
using Api.Services.Models.ResponseModels;
using BLL.TokenHandler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CredentialService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ISecurityTokenHandler _securityTokenHandler;
        private readonly IRegistrationService _registerService;
        private readonly IUserAuthenticateService _userAuthenticateService;

        public UserController(ISecurityTokenHandler hendler, IRegistrationService registerService, IUserAuthenticateService userAuthenticateService)
        {
            _securityTokenHandler = hendler;
            _registerService = registerService;
            _userAuthenticateService = userAuthenticateService;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("Registration")]
        public async Task<ActionResult<RegistrationResponse>> Registration(RegistrationRequest user)
        {
            try
            {
                var newUser = await _registerService.Register(user);

                if (newUser is null)
                {
                    return BadRequest($"A user with email {user.Email} has already been created");
                }
                var authUser = new AuthenticateRequest
                {
                    Email = user.Email,
                    Password = user.Password,
                };

                var response = await _userAuthenticateService.Authenticate(authUser);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Authenticate")]
        public async Task<ActionResult<AuthenticateResponse>> Authenticate(AuthenticateRequest authenticateRequest)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var user = await _userAuthenticateService.Authenticate(authenticateRequest);
            if (user is null)
            {
                return Unauthorized();
            }
            return Ok(user);
        }

        [HttpPost]
        [Route("GetAll")]
        [Authorize]
        public ActionResult GetAll()
        {
            return Ok();
        }
    }
}
