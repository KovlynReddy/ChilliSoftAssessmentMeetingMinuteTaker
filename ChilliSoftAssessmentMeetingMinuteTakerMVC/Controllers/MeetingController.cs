using ChilliSoftAssessmentMeetingMinuteTakerDLL.DomainModels;
using ChilliSoftAssessmentMeetingMinuteTakerDLL.Dtos;
using ChilliSoftAssessmentMeetingMinuteTakerDLL.ViewModels;
using ChilliSoftAssessmentMeetingMinuteTakerMVC.Hubs;
using GenericBaseMVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ChilliSoftAssessmentMeetingMinuteTakerMVC.Controllers;

[Authorize]
public class MeetingController : Controller
{
    public IHubContext<MeetingHub> _hub { get; set; }
    public MeetingController(IHubContext<MeetingHub> hub)
    {
        _hub = hub;
    }


    public async Task<MeetingViewModel> AssembleMeetingModel(int meetingId) {
        int MeetingId;

        if (meetingId < 1)
        {
            MeetingId = 0;
        }
        else
        {

            MeetingId = meetingId;
        }
        #region FetchFromAPI

        var model = new MeetingViewModel();
        var Users = await UserService.GetAll();
        var AllMessages = await MeetingMinutesService.GetAll();
        var AllMeetingItems = await MeetingItemService.GetAll();
        var AllMeetings = await MeetingService.GetAll();
        var AllStatuses = await MeetingItemService.GetAllStatuses();
        var AllTypes = await MeetingService.GetAllTypes();


        #endregion

        #region MessageDToToVM
        var MessageVMs = new List<MeetingMessageViewModel>();
        foreach (var item in AllMessages)
        {
            var entity = new MeetingMessageViewModel()
            {
                Message = item.Message,
                CreationDateTime = item.CreationDateTime,
                ItemId = item.ItemId,
                SenderId = item.CreatorId,
                MeetingId = item.MeetingId,
                CreatorId = item.UserId,
                Id = item.Id
            };
            MessageVMs.Add(entity);
        }

        #endregion

        #region MeetingDToToVM

        var MeetingVMs = new List<MeetingHeaderViewModel>();
        foreach (var item in AllMeetings)
        {
            var entity = new MeetingHeaderViewModel()
            {
                MeetingName = item.MeetingName,
                CreationDateTime = item.CreationDateTime,
                CreatorId = item.CreatorId,
                MeetingStatus = item.MeetingStatus,
                MeetingTypeId = item.MeetingTypeId,
                Id = item.Id,
                AllTypes = AllTypes
            };
            MeetingVMs.Add(entity);
        }

        #endregion
        var currentMeeting = MeetingVMs.FirstOrDefault(m => m.Id == MeetingId);
        if (currentMeeting == null) { 
            currentMeeting = new MeetingHeaderViewModel(); 
        if (AllMeetingItems.Count > 0 ) { currentMeeting.MeetingTypeId = AllMeetingItems.First().MeetingId; }
        }

        #region ItemDToToVM
        var ItemVMs = new List<MeetingItemVeiwModel>();
        foreach (var item in AllMeetingItems)
        {
            var entity = new MeetingItemVeiwModel()
            {
                ItemName = item.ItemName,
                CreationDateTime = item.CreationDateTime,
                StatusId = item.StatusId,
                Comment = item.Comment,
                CreatorId = item.CreatorId,
                MeetingId = item.MeetingId,
                UserId = item.UserId,
                Id = item.Id,
                Statuses = AllStatuses,
                CurrentMeetingTypeId = currentMeeting.MeetingTypeId,
                MeetingType = item.MeetingType
            };
            ItemVMs.Add(entity);
        }

        #endregion
        var MyProfile = Users.FirstOrDefault(m => m.UserEmail == User.Identity.Name);

        var newMessage = new SendMeetingMessageViewModel()
        {
            SenderId = MyProfile.Id,
            MeetingId = MeetingId
        };

        model.MeetingId = MeetingId;
        model.newMeeting = new CreateMeetingViewModel() { MeetingTypes = AllTypes };
        model.newItem = new CreateMeetingItemViewModel() { Meetings = MeetingVMs, Statuses = AllStatuses };
        model.NewMessage = newMessage;
        model.OtherMeetings = MeetingVMs;
        model.Messages = MessageVMs;
        model.Items = ItemVMs;
        model.MeetingName = currentMeeting.MeetingName;
        model.MeetingTypeId = currentMeeting.MeetingTypeId;

        return(model);
    }

    // GET: MeetingController
    public async Task<ActionResult> Index()
    {
        var model = await AssembleMeetingModel(0);

        return View(model);
    }
    public async Task<IActionResult> AttendMeeting(string Id)
    {

        var model = await AssembleMeetingModel(Convert.ToInt32(Id));

        return View("Index", model);
    }

    [HttpPost]
    public async Task<IActionResult> SendMeetingMessage(SendMeetingMessageViewModel model) {

        await MeetingMinutesService.Create(model);

        var SRMessage = new SignalRMessage() { 
        Message = model.Message,
        UserId = model.SenderId,
        ItemId = model.ItemId,
        MeetingId = model.MeetingId
        };

        await SendAMessage(SRMessage);

        return RedirectToAction("AttendMeeting",model.MeetingId);
    }

    public async Task<IActionResult> SendAMessage(SignalRMessage Message) {
        await _hub.Clients.All.SendAsync("RecieveMessage",Message);
        return View();
    }

    public IActionResult OnGoingMeeting() {

        return View();
    }

    public async Task<IActionResult> CreateNewMeeting(CreateMeetingViewModel newMeeting) {
        var Users =  await UserService.GetAll();
        var MyProfile = Users.FirstOrDefault(m => m.UserEmail == User.Identity.Name);
        newMeeting.CreatorId = MyProfile.Id;
        MeetingService.Create(newMeeting);

        var SRMessage = new SignalRMessage()
        {
            Code = 101
        };

        await SendAMessage(SRMessage);

        return RedirectToAction("Index");
    }


}
