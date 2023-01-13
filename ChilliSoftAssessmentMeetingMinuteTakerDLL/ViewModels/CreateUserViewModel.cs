namespace ChilliSoftAssessmentMeetingMinuteTakerDLL.ViewModels;

public class CreateUserViewModel
{
    public string UserFirstName { get; set; } = string.Empty;
    public string UserLastName { get; set; } = string.Empty;
    public string UserEmail { get; set; } = string.Empty;
    public int CreatorId { get; set; }
    public int UserPosition { get; set; } 
}
