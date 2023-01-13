namespace ChilliSoftAssessmentMeetingMinuteTakerDLL.ViewModels;

public class MeetingViewModel
{
    public int MeetingId { get; set; }
    public int MeetingTypeId { get; set; }
    public string MeetingName { get; set; }
    public CreateMeetingItemViewModel newItem { get; set; }
    public CreateMeetingViewModel newMeeting { get; set; }
    public List<MeetingMessageViewModel> Messages { get; set; } = new List<MeetingMessageViewModel>();
    public SendMeetingMessageViewModel NewMessage { get; set; } = new SendMeetingMessageViewModel();
    public List<MeetingItemVeiwModel> Items { get; set; } = new List<MeetingItemVeiwModel>();
    public List<MeetingHeaderViewModel> OtherMeetings { get; set; } = new List<MeetingHeaderViewModel>();
}
