using Library.Models;
using Library.Repositories;
using Library.Repositories.Account;
using Library.ViewModel.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Library.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IWishListRepository wishListRepository;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IAccountRepository accountRepository,
            IWishListRepository wishListRepository
            )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            AccountRepository = accountRepository;
            this.wishListRepository = wishListRepository;
        }

        public IAccountRepository AccountRepository { get; }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser();
                //transfer view model Data To ApplicationUser Class Object
                user.UserName = model.UserName;
                user.Address = model.Address;
                user.PhoneNumber = model.Phone;
                user.BirthDate = model.BirthDate;
                user.PasswordHash = model.Password;
                user.Gender = model.Gender;
                user.Email = model.Email;
                //insert in DB
                IdentityResult result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user,"Visitor");
                    //here we create Cookie
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    //if there is any error of the model send to view .
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
                return View(model);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var userByEmail = await userManager.FindByEmailAsync(model.UserName);
                var userByName = await userManager.FindByNameAsync(model.UserName);
                if(userByEmail!=null || userByName != null)
                {
                    bool checkPasswordWithEmail, checkPasswordWithUserName;
                    //not working with email, why ?
                    if (userByEmail != null)
                    {
                         checkPasswordWithEmail = await userManager.CheckPasswordAsync(userByEmail, model.Password);
                        if (checkPasswordWithEmail == true)
                        {
                            //List<Claim> claims = new List<Claim>();
                            //claims.Add(new Claim("WishListCount", "30"));
                            //await signInManager.SignInWithClaimsAsync(userByEmail, isPersistent: model.RememberMe,claims);
                            
                            await signInManager.SignInAsync(userByEmail, isPersistent: model.RememberMe);

                        }
                    }
                    else if (userByName != null)
                    {
                        checkPasswordWithUserName = await userManager.CheckPasswordAsync(userByName, model.Password);
                        if (checkPasswordWithUserName == true)
                        {
                            await signInManager.SignInAsync(userByName, isPersistent: model.RememberMe);
                        }
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "UserName Or Password Or Both InCorrect !");
                }
            }
            
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
             await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

    }
}
