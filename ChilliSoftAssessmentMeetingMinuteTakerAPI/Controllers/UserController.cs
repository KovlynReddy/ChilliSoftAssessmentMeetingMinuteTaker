using ChilliSoftAssessmentMeetingMinuteTakerAPI.Data.DataAccess.Interfaces;
using ChilliSoftAssessmentMeetingMinuteTakerDLL.DomainModels;
using ChilliSoftAssessmentMeetingMinuteTakerMVC.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChilliSoftAssessmentMeetingMinuteTakerAPI.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : Controller
    {
        public MeetingDbContext _Db { get; set; }
        public IUserDB _UserDB { get; set; }
        public UserController(MeetingDbContext DB,IUserDB userDB)
        {
            _UserDB = userDB;
            _Db = DB;
        }
        // GET: UserController
        public ActionResult Index(string Email)
        {
            return View();
        }

        [HttpGet]
        [Route("~/api/User/GetAll")]
        public ActionResult GetAll()
        {
            var results = _UserDB.GetAll();

            var dtos = new List<UserDto>();
            if (results.Count > 0)
            {

                foreach (var item in results)
                {
                    var entity = new UserDto()
                    {
                        UserFirstName = item.UserFirstName,
                        UserLastName = item.UserLastName,
                        UserEmail = item.UserEmail,
                        UserPositionCode = item.UserPositionCode,
                        CreationDateTime = item.CreationDateTime,
                        CreatorId = item.CreatorId,
                        Id = item.Id

                    };
                    dtos.Add(entity);
                }
            }
            return Ok(dtos);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        [HttpPost]
        [Route("~/api/User/Create")]
        public ActionResult Create(CreateUserDto model)
        {
            _UserDB.Create(model);
            return Ok();
        }

        // POST: UserController/Create
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

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
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

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
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
