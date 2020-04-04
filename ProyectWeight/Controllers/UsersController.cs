using Contracts;
using Entities.ExtendedModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ProyectWeight.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private ILoggerManager _logger;
        private IUsers _userService;

        public UsersController(IUsers userService, ILoggerManager logger)
        {
            _logger = logger;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] CorpCustomersExtended userParam)
        {
            try
            {
                var user = _userService.Authenticate(userParam.Email, userParam.Password);

                if (user == null)
                {
                    _logger.LogError($"email or password incorrect in Authenticate");
                    return BadRequest(new { message = "Email or Password is incorrect" });
                }
                _logger.LogInfo($"Customer: {user} loegado");
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Authenticate action: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}