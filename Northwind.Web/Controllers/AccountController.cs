using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Northwind.Contracts.Dto.Authentication;
using Northwind.Domain.Models;
using System.Threading.Tasks;

namespace Northwind.Web.Controllers
{
    public class AccountController : Controller
    {
        //construktor
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        //untuk sign / lgin
        private readonly SignInManager<User> _signInManager;

        public AccountController(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        //get nampilkan data
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto, string returnUrl=null)
        {
            if (!ModelState.IsValid)
            {
                return View(userLoginDto);
            }
            //cek validasi email dan password
            var result = await _signInManager.PasswordSignInAsync(userLoginDto.Email,
                userLoginDto.Password, userLoginDto.RememberMe, false);
            if (result.Succeeded)
            {
                return RedirecToLocal(returnUrl);
            }
            else
            {
                ModelState.AddModelError("", "Invalid Password or User Name");
                return View();
            }
            
        }
        private IActionResult RedirecToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register( UserRegistrationDto userRegistrationDto)
        {
            if (!ModelState.IsValid)
            {
                return View(userRegistrationDto);
            }
            //maping user  & dto
            var userModel = _mapper.Map<User>(userRegistrationDto);
            //create user to Db
            var result = await _userManager.CreateAsync(userModel,userRegistrationDto.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return View(userRegistrationDto);
            }
            else
            {
                await _userManager.AddToRoleAsync(userModel, "Manager");
            }
            return RedirectToAction(nameof(AccountController.Login), "Account");
        }

        //Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(AccountController.Login), "Account");
        }
    }
}
