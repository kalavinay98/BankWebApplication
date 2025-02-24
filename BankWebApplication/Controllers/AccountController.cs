using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BankWebApplication.Data;
using BankWebApplication.ViewModels;

public class AccountController : Controller
{
    private readonly UserManager<UsersTable> _userManager;
    private readonly SignInManager<UsersTable> _signInManager;

    public AccountController(UserManager<UsersTable> userManager, SignInManager<UsersTable> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new UsersTable
            {
                UserName = model.Email,
                Email = model.Email,
                FullName = model.FullName,
                Role = "User" // Default role
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        return View(model);
    }
}