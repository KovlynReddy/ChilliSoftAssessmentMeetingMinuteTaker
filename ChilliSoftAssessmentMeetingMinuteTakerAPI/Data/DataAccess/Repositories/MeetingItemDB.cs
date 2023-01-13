using ChilliSoftAssessmentMeetingMinuteTakerAPI.Data.DataAccess.Interfaces;
using ChilliSoftAssessmentMeetingMinuteTakerDLL.DomainModels;
using ChilliSoftAssessmentMeetingMinuteTakerMVC.Data;
using Microsoft.AspNetCore.Http;

namespace ChilliSoftAssessmentMeetingMinuteTakerAPI.Data.DataAccess.Repositories;

public class MeetingItemDB : IMeetingItemDB
{
    public MeetingDbContext _Db { get; set; }
    public MeetingItemDB(MeetingDbContext Db)
    {
        _Db = Db;
    }
    public Item Create(CreateItemDto model)
    {
        var newEntity = new Item()
        {
            MeetingType = model.MeetingType,
            ItemName = model.ItemName,
            CreatorId = model.CreatorId,
            Comment = model.Comment,
            MeetingId = model.MeetingId,
            CreationDateTime = DateTime.Now,
            LastUpdated = DateTime.Now,
            StatusId = model.StatusId
        };

        _Db.Add(newEntity);
        _Db.SaveChanges();

        return newEntity;
    }

    public Item Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Item Get(int id)
    {
        throw new NotImplementedException();
    }

    public List<Item> GetAll()
    {
        var results = _Db.MeetingItems.ToList();
        //var dtos = new List<ItemDto>();
        //foreach (var item in results)
        //{
        //    var entity = new ItemDto()
        //    {
        //        ItemName = item.ItemName,
        //        CreationDateTime = item.CreationDateTime,
        //        StatusId = item.StatusId,
        //        Comment = item.Comment,
        //        CreatorId = item.CreatorId,
        //        MeetingId = item.MeetingId,
        //        UserId = item.UserId,
        //        Id = item.Id
        //    };
        //    dtos.Add(entity);
        //}

        return(results);
    }

    public Item Update(CreateItemDto model)
    {
        Item updatedItem = _Db.MeetingItems.ToList().FirstOrDefault(m=>m.Id==model.Id);
        updatedItem.StatusId = model.StatusId;
        updatedItem.ItemName = model.ItemName;
        updatedItem.Comment = model.Comment;

        _Db.Update(updatedItem);
        _Db.SaveChanges();

        return (updatedItem);
    }

    public List<ItemStatus> GetAllStatuses()
    {
        var results = _Db.ItemStatis.ToList();

        return(results);
    }

    public ItemStatus CreateStatus(ItemStatus newStatus)
    {
        _Db.Add(newStatus);
        _Db.SaveChanges();

        return (newStatus);
    }
}
