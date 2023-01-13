using ChilliSoftAssessmentMeetingMinuteTakerDLL.Dtos;

namespace ChilliSoftAssessmentMeetingMinuteTakerDLL.DomainModels;

public class MeetingDto : BaseDto
{
    public string MeetingName { get; set; } = string.Empty;
    public int MeetingTypeId { get; set; }
    public int MeetingStatus { get; set; }
}
