namespace ChilliSoftAssessmentMeetingMinuteTakerDLL.DomainModels;
public class ItemStatus : BaseModel
{
    public int StatusPosition { get; set; }
    public string StatusName { get; set; } = string.Empty;
    public string StatusCode { get; set; } = string.Empty;
}
