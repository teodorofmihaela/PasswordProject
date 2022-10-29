using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using PasswordApi.Core.Interfaces;
using PasswordApi.Core.Models;

namespace PasswordApi.Presentation.Controllers;

public class TemporaryPasswordsController
{
    private readonly ITemporaryPasswordService _service;
    private readonly ILogger<TemporaryPasswordsController> _logger;

    public TemporaryPasswordsController(ITemporaryPasswordService service,
        ILogger<TemporaryPasswordsController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet]
    [Route("/password")]
    public async Task<TemporaryPassword> GenerateTemporaryPassword([FromQuery] Guid userId)
    {
        try
        {
            return await _service.GenerateTemporaryPassword(userId);
        }
        catch (Exception exception)
        {
            _logger.LogCritical(exception, "Unhandled unexpected exception while generating a temporary password");
            return null;
        }
    }
}