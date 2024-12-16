using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using yum_admin.Models;
using Microsoft.AspNetCore.Authentication;

namespace yum_admin.Controllers
{
    public class AuthController : Controller
    {
        private readonly YumyumdbContext _context;
        
        public AuthController(YumyumdbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var admin = _context.Admins.FirstOrDefault(a => a.AdminEmail == email && a.AdminPassword == password);

            if (admin != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, admin.AdminName),
                    new Claim(ClaimTypes.Email, admin.AdminEmail)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                };

                await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

                return RedirectToAction("Index", "UserSecretInfoes");
            }

            ModelState.AddModelError("", "Invalid email or password");
            return View();
        }

        //有雜湊值登入(等全部加密完再開啟)

        //[AllowAnonymous]
        //[HttpPost]
        //public async Task<IActionResult> Login(string email, string password)
        //{
        //    // Find the admin by email
        //    var admin = _context.Admins.FirstOrDefault(a => a.AdminEmail == email);

        //    if (admin != null)
        //    {
        //        // Use bcrypt to verify if the entered password matches the hashed password stored in the database
        //        if (BCrypt.Net.BCrypt.Verify(password, admin.AdminPassword))
        //        {
        //            var claims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.Name, admin.AdminName),
        //        new Claim(ClaimTypes.Email, admin.AdminEmail)
        //    };

        //            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        //            var authProperties = new AuthenticationProperties
        //            {
        //                IsPersistent = true,
        //            };

        //            await HttpContext.SignInAsync(
        //                CookieAuthenticationDefaults.AuthenticationScheme,
        //                new ClaimsPrincipal(claimsIdentity),
        //                authProperties);

        //            return RedirectToAction("Index", "UserSecretInfoes");
        //        }
        //    }

        //    // If the login fails, add an error to the model state and return the view
        //    ModelState.AddModelError("", "Invalid email or password");
        //    return View();
        //}


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
