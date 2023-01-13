namespace ChilliSoftAssessmentMeetingMinuteTakerDLL.DomainModels;
public class Item : BaseModel   
{

    public int MeetingId { get; set; }
    public int StatusId { get; set; }
    public int UserId { get; set; }


    public int MeetingType { get; set; }
    public string ItemName { get; set; } = string.Empty;
    public string Comment { get; set; } = string.Empty;
}
