using EasyCashIdentityProject.BusinessLayer.Abstract;
using EasyCashIdentityProject.DataAccessLayer.Concrete;
using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    public class MyLastProcessController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly ICustomerAccountProcessService customerAccountProcessService;

        public MyLastProcessController(UserManager<AppUser> userManager, ICustomerAccountProcessService customerAccountProcessService)
        {
            this.userManager = userManager;
            this.customerAccountProcessService = customerAccountProcessService;
        }

        public async Task<IActionResult> Index()
        {
            var context = new Context();
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            int customerAccountID = context.CustomerAccounts.Where(x => x.AppUserId == user.Id && x.CustomerCurrency == "Türk Lirası").Select(x => x.CustomerAccountID).First();
            var values = customerAccountProcessService.MyLastProcess(customerAccountID);
            return View(values);
        }
    }
}