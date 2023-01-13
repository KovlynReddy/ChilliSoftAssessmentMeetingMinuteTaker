using ChilliSoftAssessmentMeetingMinuteTakerAPI.Data.DataAccess.Interfaces;
using ChilliSoftAssessmentMeetingMinuteTakerAPI.Data.DataAccess.Repositories;
using ChilliSoftAssessmentMeetingMinuteTakerDLL.DomainModels;
using ChilliSoftAssessmentMeetingMinuteTakerDLL.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChilliSoftAssessmentMeetingMinuteTakerAPI.Controllers
{
    [Route("api/MeetingMinutes")]
    [ApiController]
    public class MeetingMinutesController : Controller
    {

        public IMeetingItemDB _MeetingitemDb { get; set; }
        public IMeetingDB _MeetingDb { get; set; }
        public IMeetingMinutesDB _MeetingMinutesDb { get; set; }
        public MeetingMinutesController(IMeetingItemDB meetingitemDb, IMeetingDB meetingDb, IMeetingMinutesDB meetingMinutesDb)
        {
            _MeetingDb = meetingDb;
            _MeetingitemDb = meetingitemDb;
            _MeetingMinutesDb = meetingMinutesDb;
        }

        // GET: MeetingMinutesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MeetingMinutesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


            // GET: MeetingMinutesController/Create
            [HttpPost]
        [Route("~/api/MeetingMinutes/Create")]

        public ActionResult Create(CreateMinutesDto model)
        {
            _MeetingMinutesDb.Create(model);

            return Ok();
        }

        [HttpGet]
        [Route("~/api/MeetingMinutes/GetAll")]
        public ActionResult GetAll()
        {
            var results = _MeetingMinutesDb.GetAll();
            var dtos = new List<MinutesDto>();
            if (results.Count > 0)
            {
                foreach (var item in results)
                {
                    var entity = new MinutesDto()
                    {
                        Message = item.Message,
                        CreationDateTime = item.CreationDateTime,
                        ItemId = item.ItemId,
                        CreatorId = item.CreatorId,
                        MeetingId = item.MeetingId,
                        UserId = item.UserId,
                        Id = item.Id
                    };
                    dtos.Add(entity);
                }
            }

            return Ok(dtos);
        }

        // POST: MeetingMinutesController/Create
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

        // GET: MeetingMinutesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MeetingMinutesController/Edit/5
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

        // GET: MeetingMinutesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MeetingMinutesController/Delete/5
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
}
