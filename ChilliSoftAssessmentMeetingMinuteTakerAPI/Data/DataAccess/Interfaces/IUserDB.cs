using ChilliSoftAssessmentMeetingMinuteTakerDLL.DomainModels;

namespace ChilliSoftAssessmentMeetingMinuteTakerAPI.Data.DataAccess.Interfaces
{
    public interface IUserDB
    {
        public User Create(CreateUserDto model);
        public List<User> GetAll();
        public User Get(int Id);
        public User GetByEmail(string Email);
        public User Delete(int id);
        public User Update(UserDto model);
    }
}
