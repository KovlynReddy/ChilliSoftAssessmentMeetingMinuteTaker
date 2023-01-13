using ChilliSoftAssessmentMeetingMinuteTakerDLL.DomainModels;

namespace ChilliSoftAssessmentMeetingMinuteTakerDLL.ViewModels;

public class CreateMeetingViewModel
{
    public int CreatorId { get; set; } 
    public string MeetingName { get; set; } = string.Empty;
    public int MeetingTypeId { get; set; }
    public string MeetingTypeGuid { get; set; } = string.Empty;
    public int MeetingStatus { get; set; }
    public string MeetingGuid { get; set; } = string.Empty;
    public List<MeetingType>? MeetingTypes { get; set; } = new List<MeetingType>();
}
