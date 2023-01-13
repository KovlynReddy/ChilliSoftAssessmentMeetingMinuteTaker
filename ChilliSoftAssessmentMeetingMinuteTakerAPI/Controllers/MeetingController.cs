using ChilliSoftAssessmentMeetingMinuteTakerAPI.Data.DataAccess.Interfaces;
using ChilliSoftAssessmentMeetingMinuteTakerAPI.Data.DataAccess.Repositories;
using ChilliSoftAssessmentMeetingMinuteTakerDLL.DomainModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChilliSoftAssessmentMeetingMinuteTakerAPI.Controllers;

[Route("api/Meeting")]
[ApiController]
public class MeetingController : Controller
{
    public IMeetingItemDB _MeetingitemDb { get; set; }
    public IMeetingDB _MeetingDb { get; set; }
    public IMeetingMinutesDB _MeetingMinutesDb { get; set; }
    public MeetingController(IMeetingItemDB meetingitemDb , IMeetingDB meetingDb,IMeetingMinutesDB meetingMinutesDb)
    {
        _MeetingDb = meetingDb;
        _MeetingitemDb = meetingitemDb;
        _MeetingMinutesDb = meetingMinutesDb;
    }
    // GET: MeetingController

    [HttpGet]
    [Route("~/api/Meeting/Get")]
    public ActionResult Get()
    {
        return Ok();
    }


    // GET: MeetingController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    [HttpGet]
    [Route("~/api/Meeting/GetAll")]
    public ActionResult GetAll()
    {
        var results = _MeetingDb.GetAll();

        var dtos = new List<MeetingDto>();
        if (results.Count > 0)
        {
            foreach (var item in results)
            {
                var entity = new MeetingDto()
                {
                    MeetingName = item.MeetingName,
                    CreationDateTime = item.CreationDateTime,
                    CreatorId = item.CreatorId,
                    MeetingStatus = item.MeetingStatus,
                    MeetingTypeId = item.MeetingTypeId,
                    Id = item.Id
                };
                dtos.Add(entity);
            }
        }


        return Ok(results);
    }

    [HttpGet]
    [Route("~/api/Meeting/GetAllTypes")]
    public ActionResult GetAllTypes()
    {
        var results = _MeetingDb.GetAllTypes();
        return Ok(results);
    }

    [HttpPost]
    [Route("~/api/Meeting/CreateType")]
    public ActionResult CreateType(MeetingType model)
    {
        _MeetingDb.CreateMeetingType(model);

        return Ok();
    }


    // GET: MeetingController/Create
    [HttpPost]
    [Route("~/api/Meeting/Create")]
    public ActionResult Create(CreateMeetingDto model)
    {
        _MeetingDb.Create(model);

        return Ok();
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
