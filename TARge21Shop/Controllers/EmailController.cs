using Microsoft.AspNetCore.Mvc;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Models.Email;

namespace TARge21Shop.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailServices _emailServices;

        public EmailController(IEmailServices emailServices)
        {
            _emailServices = emailServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendEmail(EmailViewModel vm)
        {

            var dto = new EmailDto()
            {
                To = vm.To,
                Subject = vm.Subject,
                Body = vm.Body,
            };
            
            _emailServices.SendEmail(dto);

            return RedirectToAction(nameof(Index));
        }
    }
}