using Exam.Core.Models;
using Exam_pre.Areas.manage.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Exam_pre.Areas.manage.Controllers
{
    [Area("Manage")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager,SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginViewModel vm) 
        {

            var user = await _userManager.FindByNameAsync(vm.Username);
            if (user == null) 
            {
                ModelState.AddModelError("", "username or password incorrect");
                return View();
            }
            if(user!=null)
            {
                await _signInManager.PasswordSignInAsync(user, vm.Password,false,false);
            }
            return View();
        }


        //public async Task<IActionResult> CreateAdmin()
        //{

        //    AppUser appUser = new AppUser
        //    {
        //        FullName = "Mehemmed",
        //        UserName = "SuperAdmin",
        //        Email = "mehemmedmemmedov1@gmail.com"
                
        //    };


        //    await _userManager.CreateAsync( appUser,"Admin123@" );

        //    await _userManager.AddToRoleAsync(appUser, "SuperAdmin");

           

        //    return Ok("yarandi");
        //}

        //public async  Task<IActionResult> CreateRole()
        //{
        //    IdentityRole role1 = new IdentityRole("SuperAdmin");
        //    IdentityRole role2 = new IdentityRole("Admin");
        //    IdentityRole role3 = new IdentityRole("Member");


        //   await _roleManager.CreateAsync(role3);
        //   await _roleManager.CreateAsync(role2);
        //   await _roleManager.CreateAsync(role1);

        //    return Ok("yarandi");
        //}
    }
}
