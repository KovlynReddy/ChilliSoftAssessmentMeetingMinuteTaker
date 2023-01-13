namespace ChilliSoftAssessmentMeetingMinuteTakerDLL.ViewModels;

public class UpdateMeetingItemViewModel
{
    public int MeetingId { get; set; }
    public int StatusId { get; set; }
    public int UserId { get; set; }

    public string MeetingGuid { get; set; } = string.Empty;
    public string UserGuid { get; set; } = string.Empty;
    public string StatusGuid { get; set; } = string.Empty;

    public string Comment { get; set; } = string.Empty;
}
