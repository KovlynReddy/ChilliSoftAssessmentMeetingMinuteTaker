using ChilliSoftAssessmentMeetingMinuteTakerAPI.Data.DataAccess.Interfaces;
using ChilliSoftAssessmentMeetingMinuteTakerAPI.Data.DataAccess.Repositories;
using ChilliSoftAssessmentMeetingMinuteTakerDLL.DomainModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChilliSoftAssessmentMeetingMinuteTakerAPI.Controllers
{
    [Route("api/MeetingItems")]
    [ApiController]
    public class ItemController : Controller
    {
        public IMeetingItemDB _MeetingitemDb { get; set; }
        public IMeetingDB _MeetingDb { get; set; }
        public IMeetingMinutesDB _MeetingMinutesDb { get; set; }
        public ItemController(IMeetingItemDB meetingitemDb, IMeetingDB meetingDb, IMeetingMinutesDB meetingMinutesDb)
        {
            _MeetingDb = meetingDb;
            _MeetingitemDb = meetingitemDb;
            _MeetingMinutesDb = meetingMinutesDb;
        }


        [HttpGet]
        [Route("~/api/MeetingItems/GetAllItemStatuses")]
        public ActionResult GetAllItemStatuses()
        {
            var results = _MeetingitemDb.GetAllStatuses();
            return Ok(results);
        }

        // GET: ItemController
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("~/api/MeetingItems/GetAll")]
        public ActionResult GetAll()
        {
            var results = _MeetingitemDb.GetAll();

            var dtos = new List<ItemDto>();
            if (results.Count > 0)
            {

                foreach (var item in results)
                {
                    var entity = new ItemDto()
                    {
                        ItemName = item.ItemName,
                        CreationDateTime = item.CreationDateTime,
                        StatusId = item.StatusId,
                        Comment = item.Comment,
                        CreatorId = item.CreatorId,
                        MeetingId = item.MeetingId,
                        MeetingType = item.MeetingType,
                        UserId = item.UserId,
                        Id = item.Id
                    };
                    dtos.Add(entity);
                }
            }
            return Ok(dtos);
        }

        // GET: ItemController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        [Route("~/api/MeetingItems/CreateStatus")]
        public ActionResult CreateStatus(ItemStatus model)
        {


            _MeetingitemDb.CreateStatus(model);
            return Ok();
        }


        [HttpPost]
        [Route("~/api/MeetingItems/Update")]

        public ActionResult Update(CreateItemDto model)
        {
            _MeetingitemDb.Update(model);

            return Ok();
        }

        // GET: ItemController/Create
        [HttpPost]
        [Route("~/api/MeetingItems/Create")]
        public ActionResult Create(CreateItemDto  model)
        {


            _MeetingitemDb.Create(model);
            return Ok();
        }

        // POST: ItemController/Create
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

        // GET: ItemController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ItemController/Edit/5
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

        // GET: ItemController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ItemController/Delete/5
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
