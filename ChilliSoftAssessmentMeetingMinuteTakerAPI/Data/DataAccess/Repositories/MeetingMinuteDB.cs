using ChilliSoftAssessmentMeetingMinuteTakerAPI.Data.DataAccess.Interfaces;
using ChilliSoftAssessmentMeetingMinuteTakerDLL.DomainModels;
using ChilliSoftAssessmentMeetingMinuteTakerMVC.Data;

namespace ChilliSoftAssessmentMeetingMinuteTakerAPI.Data.DataAccess.Repositories;

public class MeetingMinuteDB : IMeetingMinutesDB
{
    public MeetingDbContext _Db { get; set; }
    public MeetingMinuteDB(MeetingDbContext Db)
    {
        _Db = Db;
    }

    public Minutes Create(CreateMinutesDto model)
    {
        var newEntity = new Minutes()
        {
            CreatorId = model.CreatorId,   
            ItemId = model.ItemId,
            Message = model.Message,
            MeetingId = model.MeetingId,
            CreationDateTime = DateTime.Now,
            LastUpdated = DateTime.Now
        };

        _Db.Add(newEntity);
        _Db.SaveChanges();

        return newEntity;
    }

    public Minutes Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Minutes Get(int id)
    {
        throw new NotImplementedException();
    }

    public List<Minutes> GetAll()
    {
        var resuls = _Db.MeetingMinutes.ToList();
        return (resuls);
    }

    public Minutes Update(MinutesDto model)
    {
        throw new NotImplementedException();
    }
}
