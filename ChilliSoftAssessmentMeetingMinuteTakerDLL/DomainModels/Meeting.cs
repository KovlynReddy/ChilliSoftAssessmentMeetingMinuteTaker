namespace ChilliSoftAssessmentMeetingMinuteTakerDLL.DomainModels;
public class Meeting : BaseModel
{
    public string MeetingName { get; set; } = string.Empty;
    public int MeetingTypeId { get; set; }
    public int MeetingStatus { get; set; }

}
