using ChilliSoftAssessmentMeetingMinuteTakerDLL.DomainModels;

namespace ChilliSoftAssessmentMeetingMinuteTakerDLL.ViewModels;

public class MeetingHeaderViewModel
{
    public List<MeetingType> AllTypes { get; set; } = new List<MeetingType>();
    public string MeetingType { get; set; }
    public int Id { get; set; }
    public DateTime CreationDateTime { get; set; }
    public int CreatorId { get; set; }
    public string MeetingName { get; set; } = string.Empty;
    public int MeetingTypeId { get; set; }
    public string MeetingTypeGuid { get; set; } = string.Empty;
    public int MeetingStatus { get; set; }
    public string MeetingGuid { get; set; } = string.Empty;
}
