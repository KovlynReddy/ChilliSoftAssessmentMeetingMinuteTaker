using ChilliSoftAssessmentMeetingMinuteTakerDLL.Dtos;

namespace ChilliSoftAssessmentMeetingMinuteTakerDLL.DomainModels;

public class CreateMinutesDto : BaseDto
{
    public int MeetingId { get; set; }
    public int UserId { get; set; }
    public int ItemId { get; set; }
        
    public string MeetingGuid { get; set; } = string.Empty;
    public string UserGuid { get; set; } = string.Empty;

    public string Message { get; set; } = string.Empty;
}
