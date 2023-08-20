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

        public SendMoneyController(UserManager<AppUser> userManager, ICustomerAccountProcessService customerAccountProcessService)
        {
            _userManager = userManager;
            _customerAccountProcessService = customerAccountProcessService;
        }

        [HttpGet]
        public IActionResult Index(string mycurrency)
        {
            ViewBag.currency = mycurrency;
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

            var senderAccountNumberID = contex.CustomerAccounts.Where(x => x.AppUserID == user.Id)
                .Where(y => y.CustomerAccountCurrency == "Türk Lirası")
                .Select(z => z.CustomerAccountID).FirstOrDefault();

            var values = new CustomerAccountProcess();
            values.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            values.SenderID = senderAccountNumberID;
            values.ProcessType = "Havale";
            values.ReceiverID = receiverAccountNumberID;
            values.Amount = sendMoneyForCustomerAccountProcessDto.Amount;
            values.Description = sendMoneyForCustomerAccountProcessDto.Description;

            _customerAccountProcessService.TInsert(values);

            return RedirectToAction("Index", "Deneme");
        }
    }
}
