using ChilliSoftAssessmentMeetingMinuteTakerDLL.DomainModels;

namespace ChilliSoftAssessmentMeetingMinuteTakerAPI.Data.DataAccess.Interfaces;

public interface IMeetingDB
{
    public Meeting Create(CreateMeetingDto model);
    public List<Meeting> GetAll();
    public Meeting Get(int id);
    public Meeting Delete(int id);
    public Meeting Update(MeetingDto model);
    public List<MeetingType> GetAllTypes();
    public MeetingType CreateMeetingType(MeetingType newType);

}
