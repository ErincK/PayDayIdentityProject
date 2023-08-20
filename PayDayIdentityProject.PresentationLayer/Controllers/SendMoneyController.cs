using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PayDayIdentityProject.BusinessLayer.Abstract;
using PayDayIdentityProject.DataAccessLayer.Concrete;
using PayDayIdentityProject.DtoLayer.Dtos.CustomerAccountProcessDtos;
using PayDayIdentityProject.EntityLayer.Concrete;

namespace PayDayIdentityProject.PresentationLayer.Controllers
{
    public class SendMoneyController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICustomerAccountProcessService _customerAccountProcessService;

        public SendMoneyController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SendMoneyForCustomerAccountProcessDto sendMoneyForCustomerAccountProcessDto)
        {
            var contex = new Context();
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var receiverAccountNumberID = contex.CustomerAccounts.Where
                (x => x.CustomerAccountNumber == sendMoneyForCustomerAccountProcessDto.ReceiverAccountNumber).Select
                (y => y.CustomerAccountID).FirstOrDefault();
            sendMoneyForCustomerAccountProcessDto.SenderID = user.Id;
            sendMoneyForCustomerAccountProcessDto.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            sendMoneyForCustomerAccountProcessDto.ProcessType = "Havale";
            sendMoneyForCustomerAccountProcessDto.ReceiverID = receiverAccountNumberID;

            return RedirectToAction("Index","Deneme");
        }
    }
}
