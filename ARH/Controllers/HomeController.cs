using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ARH.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        //[AllowAnonymous]
        public IActionResult Home()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Home", "Home");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult StudentRegistration()
        {
            return View();
        }

        public IActionResult AddFeeHead()
        {
            return View();
        }

        public IActionResult AddExtraFeeHead()
        {
            return View();
        }

        public IActionResult SubjectWiseFeeHead()
        {
            return View();
        }

        public IActionResult AddNewFeeGroup()
        {
            return View();
        }

        public IActionResult AssignFeeHeadToFeeGroup()
        {
            return View();
        }

        public IActionResult AssignFeeAmountToFeeGroup()
        {
            return View();
        }

        public IActionResult AssignFeeGroupToStudent()
        {
            return View();
        }

        public IActionResult AssignManaulFeeHead()
        {
            return View();
        }

        public IActionResult AllotTansport()
        {
            return View();
        }

        public IActionResult TC()
        {
            return View();
        }

        public IActionResult Provide_Concession()
        {
            return View();
        }

        public IActionResult YearlyIncome()
        {
            return View();
        }

        public IActionResult MonthWiseIncome()
        {
            return View();
        }

        public IActionResult YearlyIncomeAfterConcession()
        {
            return View();
        }
    }
}
