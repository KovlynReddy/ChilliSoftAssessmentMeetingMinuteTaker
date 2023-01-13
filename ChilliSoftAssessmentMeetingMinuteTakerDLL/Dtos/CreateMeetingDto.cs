using ChilliSoftAssessmentMeetingMinuteTakerDLL.Dtos;

namespace ChilliSoftAssessmentMeetingMinuteTakerDLL.DomainModels;

public class CreateMeetingDto: BaseDto
{
    public string MeetingName { get; set; } = string.Empty;
    public int MeetingTypeId { get; set; }
    public string MeetingTypeGuid { get; set; } = string.Empty;
    public int MeetingStatus { get; set; }
    public string MeetingGuid { get; set; } = string.Empty;
}
