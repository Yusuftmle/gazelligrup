using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using LOCAL.Models;
using Localization.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace LOCAL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private LanguageService _localization;
        public HomeController(ILogger<HomeController> logger, LanguageService localization)
        {
            _localization = localization;
           
        }

        public IActionResult Index()
        {
            ViewBag.WelcomeMessage = _localization.Getkey("str_welcome_message").Value;
            //get culture information
            var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;
            return View();
        }

        public IActionResult İletisim()
        {

            return View();

        }
        [HttpPost]
        public IActionResult Iletisim(string name, string phone, string email, string website, string subject, string message)
        {
            MailMessage msg = new MailMessage();
            msg.Subject = subject;
            msg.From = new MailAddress("gazelligrup@gmail.com", "GAZELLİ GRUP");
            msg.To.Add(new MailAddress("gazelligrup@gmail.com", "GAZELLİ GRUP"));
            msg.Body = "<p><strong>TELEFON NUMARASI:</strong> " + phone + "</p>"
            + "<strong>AD-SOYAD:</strong> " + name + "<br/>"
            + "<strong>WEBSITE:</strong> " + website + "<br/>"
            + "<strong>GÖNDEREN EMAIL:</strong> " + email + "</p>"
            + "<p><strong>MESAJ:</strong> " + message + "</p>"
            + msg.Body;


            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.High;
            // Host ve Port Gereklidir!
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            // Güvenli bağlantı gerektiğinden kullanıcı adı ve şifrenizi giriniz.
            NetworkCredential AccountInfo = new NetworkCredential("gazelligrup@gmail.com", "gerc hslm pcgq vdrz");
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = AccountInfo;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(msg);
            TempData["SuccessMessage"] = "Mesajınız başarıyla gönderildi. Teşekkür ederiz!";
            return RedirectToAction("İletisim");

        }


        public IActionResult Galeri()
        {
            return View();
        }
        public IActionResult Hakkımızda()
        {

            return View();

        }
        public IActionResult Hizmetlerimiz()
        {
            return View();
        }
        public IActionResult varietiesOne()
        {
            return View();
        }
        public IActionResult varietiesTwo()
        {
            return View();
        }
        public IActionResult varietiesThree()
        {
            return View();
        }
        public IActionResult varietiesFour()
        {
            return View();
        }

        public IActionResult varietiesFive()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        #region Localization
        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions()
            {
                Expires = DateTimeOffset.UtcNow.AddYears(1)
            });
            return Redirect(Request.Headers["Referer"].ToString());
        }
        #endregion
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}