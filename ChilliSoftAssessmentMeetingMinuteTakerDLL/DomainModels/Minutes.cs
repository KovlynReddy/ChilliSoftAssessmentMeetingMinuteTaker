namespace ChilliSoftAssessmentMeetingMinuteTakerDLL.DomainModels;
public class Minutes : BaseModel
{
    public int MeetingId { get; set; }
    public int UserId { get; set; }
    public int ItemId { get; set; }

    public string Message { get; set; } = string.Empty;
}
