using EasyCashIdentityProject.DTOLayer.Dtos.AppUserDtos;
using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            AppUserEditDto appUserEditDto = new AppUserEditDto();
            appUserEditDto.Surname = values.Surname;
            appUserEditDto.Name = values.Name;
            appUserEditDto.PhoneNumber = values.PhoneNumber;
            appUserEditDto.Email = values.Email;
            appUserEditDto.City = values.City;
            appUserEditDto.District = values.District;
            appUserEditDto.Imageurl = values.Imageurl;
            return View(appUserEditDto);
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserEditDto appUserEditDto)
        {
            if (appUserEditDto.Password != appUserEditDto.ConfirmPassword)
            {
                return View(appUserEditDto);
            }

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            user.PhoneNumber = appUserEditDto.PhoneNumber;
            user.Surname = appUserEditDto.Surname;
            user.Name = appUserEditDto.Name;
            user.City = appUserEditDto.City;
            user.District = appUserEditDto.District;
            user.Email = appUserEditDto.Email;
            user.Imageurl = "Test";
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, appUserEditDto.Password);

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(appUserEditDto);
        }
    }
}