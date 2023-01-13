using ChilliSoftAssessmentMeetingMinuteTakerDLL.DomainModels;
using ChilliSoftAssessmentMeetingMinuteTakerDLL.Dtos;
using ChilliSoftAssessmentMeetingMinuteTakerDLL.ViewModels;
using ChilliSoftAssessmentMeetingMinuteTakerMVC.Hubs;
using GenericBaseMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ChilliSoftAssessmentMeetingMinuteTakerMVC.Controllers
{
    public class MeetingItemController : Controller
    {
        public IHubContext<MeetingHub> _hub { get; set; }
        public MeetingItemController(IHubContext<MeetingHub> hub)
        {
            _hub = hub;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SendAMessage(SignalRMessage Message)
        {
            await _hub.Clients.All.SendAsync("RecieveMessage", Message);
            return View();
        }

        public async Task<IActionResult> UpdateItem(CreateMeetingItemViewModel model)
        {
            var Users = await UserService.GetAll();
            var MyProfile = Users.FirstOrDefault(m => m.UserEmail == User.Identity.Name);

            var dto = new CreateItemDto()
            {
                CreatorId = MyProfile.Id,
                ItemName = model.ItemName,
                Comment = model.Comment,
                StatusId = model.StatusId,
                MeetingId = model.MeetingId,
                Id = model.Id
            };

            await MeetingItemService.Update(dto);

            return RedirectToAction("Index", controllerName: "Meeting");

        }
            public async Task< IActionResult> CreateNewItem(CreateMeetingItemViewModel model) {
            var Users = await UserService.GetAll();
            var AllMeetings = await MeetingService.GetAll();
            var MyProfile = Users.FirstOrDefault(m => m.UserEmail == User.Identity.Name);

            var dto = new CreateItemDto() { 
            CreatorId =MyProfile.Id ,
            ItemName = model.ItemName,
            Comment = model.Comment,
            StatusId = model.StatusId,
            MeetingId =model.MeetingId ,
            MeetingType = AllMeetings.FirstOrDefault(m=>m.Id==model.MeetingId).MeetingTypeId
            };

            await MeetingItemService.Create(dto);
            var SRMessage = new SignalRMessage()
            {
                Code = 102
            };

            await SendAMessage(SRMessage);
            return RedirectToAction("Index",controllerName:"Meeting");
        }
    }
}
