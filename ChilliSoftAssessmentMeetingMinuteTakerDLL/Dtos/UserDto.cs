using ChilliSoftAssessmentMeetingMinuteTakerDLL.Dtos;

namespace ChilliSoftAssessmentMeetingMinuteTakerDLL.DomainModels;

public class UserDto : BaseDto
{
    public string UserFirstName { get; set; } = string.Empty;
    public string UserLastName { get; set; } = string.Empty;
    public string UserEmail { get; set; } = string.Empty;
    public string UserPosition { get; set; } = string.Empty;
    public int UserPositionCode { get; set; }
    public int CreatorId { get; set; }
}
