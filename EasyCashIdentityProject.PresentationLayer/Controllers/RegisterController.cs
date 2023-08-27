using EasyCashIdentityProject.BusinessLayer.Concrete;
using EasyCashIdentityProject.DTOLayer.Dtos.AppUserDtos;
using EasyCashIdentityProject.EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
        {
            if (ModelState.IsValid)
            {
                AppUser newEntity = ObjectMapper.Mapper.Map<AppUser>(appUserRegisterDto);

                var result = await _userManager.CreateAsync(newEntity, appUserRegisterDto.Password);
                if (result.Succeeded)
                {
                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Easy Cash Admin", "peronur@gmail.com");
                    MailboxAddress mailboxAddressTo = new MailboxAddress(appUserRegisterDto.Username, "peronur@gmail.com");

                    mimeMessage.From.Add(mailboxAddressFrom);
                    mimeMessage.To.Add(mailboxAddressTo);

                    BodyBuilder bodybuilder = new BodyBuilder();

                    bodybuilder.TextBody = $"Kayıt işlemini gerçekleştirebilmeniz için onay kodunuz {newEntity.ConfirmCode}";
                    mimeMessage.Body = bodybuilder.ToMessageBody();
                    mimeMessage.Subject = "Easy Cash Onay Kodu";

                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Connect("smtp.gmail.com", 587, false);
                    smtpClient.Authenticate("peronur@gmail.com", "ljggyqnecwotjeyl");
                    smtpClient.Send(mimeMessage);
                    smtpClient.Disconnect(true);

                    TempData["Mail"] = appUserRegisterDto.Email;
                    var ss = nameof(ConfirmMailController.Index);
                    return RedirectToAction("Index", "ConfirmMail");
                }
                else
                {
                    foreach (var item in result.Errors)
                        ModelState.AddModelError("", item.Description);
                }
            }
            return View();
        }
    }
}
