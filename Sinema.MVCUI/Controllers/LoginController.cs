using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sinema.MVCUI.Identity;
using Sinema.MVCUI.Models;

namespace Sinema.MVCUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<SinemaUser> userManager;
        private readonly SignInManager<SinemaUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public LoginController(UserManager<SinemaUser> userManager
                                , SignInManager<SinemaUser> signInManager
                                , RoleManager<IdentityRole> roleManager)
        {

            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public async Task<IActionResult> Login()
        {
            LoginVM loginVM = new LoginVM();


            return View(loginVM);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            var user = await userManager.FindByEmailAsync(login.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Mail Yada Sifre Hatali");
                return View(login);
            }

            if (!await userManager.IsEmailConfirmedAsync(user))
            {
                ModelState.AddModelError("", "Mail Adresiniz onaylanmamistir");
                return View(login);
            }


            var result = await signInManager.PasswordSignInAsync(user, login.Password, login.Rememberme, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Mail Yada Sifre Hatali");
            return View(login);
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {

            RegisterVM register = new RegisterVM();
            return View(register);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            var IdentityRole = roleManager.FindByNameAsync("Admin").Result;
            if (IdentityRole == null)
            {

                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = "ADMIN";

                await roleManager.CreateAsync(role);


            }


            SinemaUser user = new SinemaUser
            {
                TcNo = register.TcNo,
                Email = register.Email,
                UserName = register.UserName
            };

            var sonuc = await userManager.CreateAsync(user, register.Password);

            if (!sonuc.Succeeded)
            {
                return View(register);
            }

            // Mail gonderme işlemi burada yapilacak.
            //aliveli6270@gmail.com
            //password :aliveli1234567890

            await userManager.AddToRoleAsync(user, "Admin");
            #region MAil Gonderme islemi

            //var code = userManager.GenerateEmailConfirmationTokenAsync(user);
            //StringBuilder mailmesaj = new StringBuilder();
            //mailmesaj.AppendLine("<html>");
            //mailmesaj.AppendLine("<head>");
            //mailmesaj.AppendLine("</head>");
            //mailmesaj.AppendLine("<body>");
            //mailmesaj.AppendLine($"<p> Merhaba {user.UserName} </p> <br>");
            //mailmesaj.AppendLine("<p> Uyelik işlminizi bitirmek icin aşagidaki linki tiklayin </p>");
            //mailmesaj.AppendLine($"<a href='http://localhost:5014/ConfirmEmail/?uid={user.Id}&code={code}'> Onaylayiniz </a>");
            //mailmesaj.AppendLine("</body>");
            //mailmesaj.AppendLine("</html>");

            //EmailHelper helper = new EmailHelper();
            //bool emailsonuc = helper.SenMail(user.Email, mailmesaj.ToString());
            //if (emailsonuc)
            //{
            //    return RedirectToAction("Index", "Home");

            //}
            //else
            //{
            //    ModelState.AddModelError("", "Mail Gonderilemedi");
            //    return View(register);
            //}

            #endregion



            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Logout()
        {
            return View();
        }
    }
}
