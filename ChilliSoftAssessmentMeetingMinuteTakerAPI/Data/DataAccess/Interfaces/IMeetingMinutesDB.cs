using ChilliSoftAssessmentMeetingMinuteTakerDLL.DomainModels;

namespace ChilliSoftAssessmentMeetingMinuteTakerAPI.Data.DataAccess.Interfaces;
public interface IMeetingMinutesDB
{
    public Minutes Create(CreateMinutesDto model);
    public List<Minutes> GetAll();
    public Minutes Get(int id);
    public Minutes Delete(int id);
    public Minutes Update(MinutesDto model);
}
