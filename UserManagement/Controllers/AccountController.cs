using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UserManagement.Dto;
using UserManagement.Models;

namespace UserManagement.Controllers
{
    [Route("api/v{VersionId:apiVersion}/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        public AccountController(UserManager<User> userManager,
            SignInManager<User> signInManager)
        {

            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            LoginDto model = new LoginDto();
            return Ok(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(model.Username);
                if (user != null && user.Username != null)
                {
                    ModelState.AddModelError("message", "Username not confirmed yet");
                    return Ok(model);

                }
                if (await userManager.CheckPasswordAsync(user, model.Password) == false)
                {
                    ModelState.AddModelError("message", "Invalid credentials");
                    return Ok(model);

                }

                var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, true);

                if (result.Succeeded)
                {
                    await userManager.AddClaimAsync(user, new Claim(ClaimTypes.Name, user.Username));
                    return RedirectToAction();
                }
                else
                {
                    ModelState.AddModelError("message", "Invalid login attempt");
                    return Ok(model);
                }
            }
            return Ok(model);
        }
    }
}
