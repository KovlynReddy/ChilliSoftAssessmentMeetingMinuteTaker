using ChilliSoftAssessmentMeetingMinuteTakerDLL.DomainModels;

namespace ChilliSoftAssessmentMeetingMinuteTakerDLL.ViewModels;
public class MeetingItemVeiwModel
{
    public int CurrentMeetingTypeId { get; set; }
    public int Id { get; set; }
    public DateTime CreationDateTime { get; set; }
    public int CreatorId { get; set; }
    public int MeetingId { get; set; }
    public int StatusId { get; set; }
    public int UserId { get; set; }
    public List<ItemStatus> Statuses { get; set; } = new List<ItemStatus>();
    public string MeetingGuid { get; set; } = string.Empty;
    public string UserGuid { get; set; } = string.Empty;
    public string StatusGuid { get; set; } = string.Empty;

    public int MeetingType { get; set; }
    public string ItemName { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Comment { get; set; } = string.Empty;
}
