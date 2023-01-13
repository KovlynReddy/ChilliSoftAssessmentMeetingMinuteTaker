using ChilliSoftAssessmentMeetingMinuteTakerAPI.Data.DataAccess.Interfaces;
using ChilliSoftAssessmentMeetingMinuteTakerDLL.DomainModels;
using ChilliSoftAssessmentMeetingMinuteTakerMVC.Data;

namespace ChilliSoftAssessmentMeetingMinuteTakerAPI.Data.DataAccess.Repositories;

public class MeetingDB : IMeetingDB
{
    public MeetingDbContext _Db { get; set; }
    public MeetingDB(MeetingDbContext Db)
    {
        _Db = Db;
    }
    public Meeting Create(CreateMeetingDto model)
    {
        var newEntity = new Meeting() { 
        CreatorId = model.CreatorId,
        MeetingName = model.MeetingName,
        MeetingStatus = 1,
        CreationDateTime = DateTime.Now,
        LastUpdated = DateTime.Now,
        MeetingTypeId = model.MeetingTypeId,
        };

        _Db.Add(newEntity);
        _Db.SaveChanges();

        return newEntity;
    }

    public Meeting Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Meeting Get(int id)
    {
        throw new NotImplementedException();
    }

    public List<Meeting> GetAll()
    {
        var resuls = _Db.Meetings.ToList();
        return (resuls);
    }

    public Meeting Update(MeetingDto model)
    {
        throw new NotImplementedException();
    }

    public List<MeetingType> GetAllTypes()
    {
        var results = _Db.MeetingTypes.ToList();

        return results;
    }

    public MeetingType CreateMeetingType(MeetingType newType)
    {
        _Db.Add(newType);
        _Db.SaveChanges();

        return (newType);
    }
}
