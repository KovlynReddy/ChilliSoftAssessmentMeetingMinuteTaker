using ChilliSoftAssessmentMeetingMinuteTakerDLL.DomainModels;

namespace ChilliSoftAssessmentMeetingMinuteTakerAPI.Data.DataAccess.Interfaces;

public interface IMeetingItemDB 
{
    public Item Create(CreateItemDto model);
    public List<Item> GetAll();
    public Item Get(int id);
    public Item Delete(int id);
    public Item Update(CreateItemDto model);

    public List<ItemStatus> GetAllStatuses();
    public ItemStatus CreateStatus(ItemStatus newStatus);

}
