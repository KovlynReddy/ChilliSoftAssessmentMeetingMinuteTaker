using ChilliSoftAssessmentMeetingMinuteTakerAPI.Data.DataAccess.Interfaces;
using ChilliSoftAssessmentMeetingMinuteTakerDLL.DomainModels;
using ChilliSoftAssessmentMeetingMinuteTakerMVC.Data;
using System.Reflection.Metadata.Ecma335;

namespace ChilliSoftAssessmentMeetingMinuteTakerAPI.Data.DataAccess.Repositories
{
    public class UserDB : IUserDB
    {
        public MeetingDbContext _Db { get; set; }
        public UserDB(MeetingDbContext Db)
        {
            _Db = Db;
        }
        public User Create(CreateUserDto model)
        {
            User newEntity = new User()
            {
                UserLastName = model.UserLastName,
                UserEmail = model.UserEmail,
                UserFirstName = model.UserFirstName,
                UserPositionCode = model.UserPosition,
                CreatorId = model.CreatorId,
                CreationDateTime = DateTime.Now,
            };

            _Db.Add(newEntity);
            _Db.SaveChanges();

            return (newEntity);
        }

        public User Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User Get(int Id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            var resuls = _Db.MeetingUsers.ToList();
            return (resuls);
        }

        public User GetByEmail(string Email)
        {
            var resuls = _Db.MeetingUsers.ToList();
            var user = resuls.FirstOrDefault(m => m.UserEmail == Email);
            return (user);
        }

        public User Update(UserDto model)
        {
            throw new NotImplementedException();
        }
    }
}
