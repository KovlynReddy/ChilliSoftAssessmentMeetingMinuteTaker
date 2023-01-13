using ChilliSoftAssessmentMeetingMinuteTakerDLL.DomainModels;
using ChilliSoftAssessmentMeetingMinuteTakerMVC.Models;
using GenericBaseMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ChilliSoftAssessmentMeetingMinuteTakerMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var types = await MeetingService.GetAllTypes();
            var statuses = await MeetingItemService.GetAllStatuses();


            if (types.Count < 1)
            {
                MeetingType MANCO = new MeetingType()
                {
                    MeetingCode = "1",
                    MeetingTypeName = "MANCO"
                };
                await MeetingService.CreateType(MANCO);
                MeetingType Finance = new MeetingType()
                {
                    MeetingCode = "2",
                    MeetingTypeName = "Finance"
                };
                await MeetingService.CreateType(Finance);
                MeetingType PTL = new MeetingType()
                {
                    MeetingCode = "3",
                    MeetingTypeName = "Project Team Leaders"
                };
                await MeetingService.CreateType(PTL);
            }

            if (statuses.Count < 1)
            {

                ItemStatus Open = new ItemStatus()
                {
                    StatusPosition = 0,
                    StatusName = "Open",
                    StatusCode = "0"
                };
                await MeetingItemService.CreateStatus(Open);
                ItemStatus InDev = new ItemStatus()
                {
                    StatusPosition = 1,
                    StatusName = "In Development",
                    StatusCode = "1"
                };
                await MeetingItemService.CreateStatus(InDev);
                ItemStatus AI = new ItemStatus()
                {
                    StatusPosition = 2,
                    StatusName = "AwaitingInvoice",
                    StatusCode = "2"
                };
                await MeetingItemService.CreateStatus(AI);
                ItemStatus Closed = new ItemStatus()
                {
                    StatusPosition = 3,
                    StatusName = "Closed",
                    StatusCode = "3"
                };
                await MeetingItemService.CreateStatus(Closed);
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}