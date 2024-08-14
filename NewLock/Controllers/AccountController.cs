using Microsoft.AspNetCore.Mvc;

namespace NewLock.Controllers;
public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;

    public AccountController(ILogger<AccountController> logger)
    {
        _logger = logger;
    }

    public IActionResult Registration()
    {
        return View();
    }
}