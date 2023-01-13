using ChilliSoftAssessmentMeetingMinuteTakerDLL.Dtos;

namespace ChilliSoftAssessmentMeetingMinuteTakerDLL.DomainModels;

public class MinutesDto : BaseDto
{
    public int MeetingId { get; set; }
    public int UserId { get; set; }
    public int ItemId { get; set; }

    public string Message { get; set; } = string.Empty;
}
