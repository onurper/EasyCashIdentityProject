﻿using EasyCashIdentityProject.EntityLayer.Concrete;
using EasyCashIdentityProject.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    public class ConfirmMailController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public ConfirmMailController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(ConfirmMailViewModel confirmMailViewModel)
        {
            var value = TempData["Mail"].ToString();
            var user = await _userManager.FindByEmailAsync(value);

            if (user.ConfirmCode == confirmMailViewModel.ConfirmCode)
                return RedirectToAction("Index", "MyProfile");

            return View();
        }
    }
}
