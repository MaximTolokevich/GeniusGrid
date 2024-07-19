using Api.Services.Interfaces;
using Api.Services.Models;
using BLL.TokenHandler;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CredentialService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ISecurityTokenHandler _securityTokenHandler;
        private readonly IRegisterService _registerService;

        public UserController(ISecurityTokenHandler hendler, IRegisterService registerService)
        {
            _securityTokenHandler = hendler;
            _registerService = registerService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterRequest user)
        {
            try
            {
                var newUser = await _registerService.Register(user);

                if (newUser is null)
                {
                    return BadRequest();
                }

                var claims = new List<Claim> {
                new(ClaimTypes.Name, user.Email)
            };

                var token = _securityTokenHandler.CreateToken(claims);

                return Ok(new { newUser.Id, newUser.Name, token });
            }
            catch(Exception e) {
                var message = e.Message;
                return BadRequest();
            }
        }
    }
}
