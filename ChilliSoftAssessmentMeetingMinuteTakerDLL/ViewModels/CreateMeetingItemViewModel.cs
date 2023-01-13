using ChilliSoftAssessmentMeetingMinuteTakerDLL.DomainModels;

namespace ChilliSoftAssessmentMeetingMinuteTakerDLL.ViewModels;

public class CreateMeetingItemViewModel
{
    public int Id { get; set; }
    public int MeetingId { get; set; }
    public int StatusId { get; set; }
    public int UserId { get; set; }

    public int MeetingType { get; set; }
    public string ItemName { get; set; } = string.Empty;
    public string Comment { get; set; } = string.Empty;
    public List<MeetingHeaderViewModel> Meetings { get; set; } = new List<MeetingHeaderViewModel>();
    public List<ItemStatus>? Statuses { get; set; } = new List<ItemStatus>();
}
