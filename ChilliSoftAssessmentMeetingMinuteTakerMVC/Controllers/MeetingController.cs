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
    // GET: MeetingController
    public async Task<ActionResult> Index()
    {
        #region FetchFromAPI

        var model = new MeetingViewModel();
        var Users = await UserService.GetAll();
        var AllMessages = await MeetingMinutesService.GetAll();
        var AllMeetingItems = await MeetingItemService.GetAll();
        var AllMeetings = await MeetingService.GetAll();
        var AllStatuses = await MeetingItemService.GetAllStatuses();
        var AllTypes = await MeetingService.GetAllTypes();

        #endregion

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
                Statuses = AllStatuses
            };
            ItemVMs.Add(entity);
        }

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

        var MyProfile = Users.FirstOrDefault(m=>m.UserEmail==User.Identity.Name);

        var newMessage = new SendMeetingMessageViewModel()
        {
            SenderId=MyProfile.Id
        };

        model.newMeeting = new CreateMeetingViewModel() { MeetingTypes = AllTypes};
        model.newItem = new CreateMeetingItemViewModel() { Meetings = MeetingVMs , Statuses=AllStatuses} ;
        model.NewMessage = newMessage ;
        model.OtherMeetings = MeetingVMs;
        model.Messages = MessageVMs;
        model.Items = ItemVMs;
 

        return View(model);
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

        return RedirectToAction("Index");
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

    public async Task<IActionResult> AttendMeeting(string Id) {
        int MeetingId;

        if (string.IsNullOrEmpty(Id))
        {
            return RedirectToAction("Index");
        }
        else { 

        MeetingId = Convert.ToInt32(Id);
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

        return View("Index",model);
    }

    // GET: MeetingController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: MeetingController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: MeetingController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: MeetingController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: MeetingController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: MeetingController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: MeetingController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
