using Microsoft.AspNetCore.Mvc;
using PasswordApi.Core.DataTransferObjects;
using PasswordApi.Core.Interfaces;

namespace PasswordApi.Presentation.Controllers;

public class LoginController
{
    private readonly ILoginService _service;
    private readonly ILogger<LoginController> _logger;

    public LoginController(ILoginService service,ILogger<LoginController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpPost]
    [Route("/login")]
    public async Task<bool> Login([FromBody] UserLoginInfo userLoginInfo)
    {
        var result = true;
        try
        {
            await _service.Login(userLoginInfo.UserId,userLoginInfo.Password);
        }
        catch (Exception exception)
        {
            _logger.LogCritical(exception, "Unhandled unexpected exception while logging in");
            result = false;
        }

        return result;
    }
}