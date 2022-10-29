using Microsoft.AspNetCore.Mvc;
using PasswordApi.Core.Interfaces;

namespace PasswordApi.Presentation.Controllers;

public class LoginController
{
    private readonly ILoginService _service;
    private readonly ILogger<LoginController> _logger;

    public LoginController(ILoginService service)
    {
        _service = service;
    }

    [HttpPost]
    [Route("/login")]
    public async Task<bool> Login([FromBody] Guid userId, [FromBody] string password)
    {
        var result = true;
        try
        {
            await _service.Login(userId, password);
        }
        catch (Exception exception)
        {
            _logger.LogCritical(exception, "Unhandled unexpected exception while logging in");
            result = false;
        }

        return result;
    }
}