using Library.Models;
using Library.ViewModel.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AdminController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            //return admin page
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                var applicationUser = new ApplicationUser();
                applicationUser.Email = model.Email;
                applicationUser.UserName = model.UserName;
                applicationUser.Address = model.Address;
                applicationUser.PhoneNumber = model.Phone;
                applicationUser.BirthDate = model.BirthDate;
                applicationUser.Gender = model.Gender;
                applicationUser.PasswordHash = model.Password;
                IdentityResult result = await userManager.CreateAsync(applicationUser, model.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(applicationUser, "Admin");
                    await signInManager.SignInAsync(applicationUser, false);
                    return RedirectToAction("Index", "Admin");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("",error.Description);
                }
            }
            return View(model); 
        }
    }
}
