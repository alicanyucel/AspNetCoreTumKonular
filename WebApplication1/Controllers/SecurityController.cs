using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Identity;
using WebApplication1.Models.Security;

namespace WebApplication1.Controllers
{
    [Route("security")]
    public class SecurityController : Controller
    {
        private UserManager<AppIdentityUser> _userManager;
        private SignInManager<AppIdentityUser> _signInManager;
        public SecurityController(UserManager<AppIdentityUser> userManager, SignInManager<AppIdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }
            var kulanici = await _userManager.FindByNameAsync(loginViewModel.UserName);
            if (kulanici != null)
            {
                if (await _userManager.IsEmailConfirmedAsync(kulanici))
                {
                    ModelState.AddModelError(string.Empty, "emailinizi dogru giriniz");
                    return View(loginViewModel);
                }
            }
            var result = await _signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.PassWord, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("index", "student");
            }
            ModelState.AddModelError(string.Empty, "login failed");
            return View(loginViewModel);
        }
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index","student");
        }
        [Route("AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(registerViewModel);
            }
            var user = new AppIdentityUser
            {
                UserName = registerViewModel.UserName,
                Email = registerViewModel.Email,
                Age = registerViewModel.Age
            };
         var result = await _userManager.CreateAsync(user,registerViewModel.Password);
            if(result.Succeeded)
            {
                var confirmationcode = _userManager.GenerateEmailConfirmationTokenAsync(user);
                var callbackurl = Url.Action("ConfirmEmail","Security",new {UserId=user.Id,code=confirmationcode.Result });
                // email gonder
                return RedirectToAction("index","student");
            }
            return View(registerViewModel);
        }
        [Route("ConfirmEmail")]
        public async Task<IActionResult> ConfirEmail(string userid,string code)
        {
            if(userid==null || code==null)
            {
                return RedirectToAction("index","student");
            }
            var user = await _userManager.FindByIdAsync(userid);
            if(user==null)
            {
                throw new ApplicationException("unable to find  the user");
            }
            var result = await _userManager.ConfirmEmailAsync(user,code);
            if(result.Succeeded)
            {
                return View("confiremail");
            }
            return RedirectToAction("index","student");
        }
        [Route("ForgetPass")]

        public IActionResult ForgetPass()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPass(string email)
        {
            if(string.IsNullOrEmpty(email))
            {
                return View();
            }
            var user = await _userManager.FindByEmailAsync(email);
            if(user==null)
            {
                return View();
            }
            var confirmcode = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callbackurl = Url.Action("ResetPass", "Security", new { userid = user.Id, code = confirmcode });
            return RedirectToAction("ForgotPassWordEmailSent");

        }
        [Route("ForgotPassWordEmailSent")]
        public IActionResult ForgotPassWordEmailSent()
        {
            return View();
        }
        [Route("ResetPassword")]
        public IActionResult ResetPassword(string userid, string code)
        {
            if (userid == null || code == null)
            {
                throw new ApplicationException(" kulanci ve code hatali ");
            }
            var model = new ResetPassViewModel{Code=code};
            return View(model);
        }
        [HttpPost]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPassViewModel resetPassViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(resetPassViewModel);
            }
            var user = await _userManager.FindByEmailAsync(resetPassViewModel.Email);
            if(user==null)
            {
                throw new ApplicationException(" kullanici yok");
            }
            var result = await _userManager.ResetPasswordAsync(user,resetPassViewModel.Code,resetPassViewModel.PassWord);
            if(result.Succeeded)
            {
                return RedirectToAction("ResetPassWordConfirm");

            }
            return View();
        }
        [Route("ResetPassWordConfirm")]
        public IActionResult ResetPassWordConfirm()
        {
            return View();

        }


    }
}