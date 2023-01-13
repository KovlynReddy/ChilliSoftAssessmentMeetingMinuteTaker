namespace ChilliSoftAssessmentMeetingMinuteTakerDLL.DomainModels;

public class BaseModel
{
    public int Id { get; set; }
    public DateTime CreationDateTime { get; set; } = DateTime.Now;
    public DateTime LastUpdated { get; set; } = DateTime.Now;
    public int IsDeleted { get; set; }
    public int CreatorId { get; set; } 
    public int EditorId { get; set; } 
    public DateTime DeletedDateTime { get; set; }
}
