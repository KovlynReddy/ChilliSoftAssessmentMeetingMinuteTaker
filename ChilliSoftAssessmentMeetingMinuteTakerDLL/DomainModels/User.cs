namespace ChilliSoftAssessmentMeetingMinuteTakerDLL.DomainModels;
public class User : BaseModel
{
    public string UserFirstName { get; set; } = string.Empty;
    public string UserLastName { get; set; } = string.Empty;
    public string UserEmail { get; set; } = string.Empty;
    public string UserPosition { get; set; } = string.Empty;
    public int UserPositionCode { get; set; }
}
