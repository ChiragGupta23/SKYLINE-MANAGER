using ARH.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ARH.Controllers
{
  
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

		public IActionResult Home()
		{
            ViewBag.verify = '1';
			return View();
		}

		public IActionResult Index()
        {
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

        //public IActionResult AssignFeeHead()
        //{
        //    return View();
        //}

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




        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}



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