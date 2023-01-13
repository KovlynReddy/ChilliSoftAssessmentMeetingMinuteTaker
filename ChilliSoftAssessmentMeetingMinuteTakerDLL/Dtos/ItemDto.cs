using ChilliSoftAssessmentMeetingMinuteTakerDLL.Dtos;

namespace ChilliSoftAssessmentMeetingMinuteTakerDLL.DomainModels
{
    public class ItemDto : BaseDto
    {
        public int MeetingId { get; set; }
        public int StatusId { get; set; }
        public int UserId { get; set; }


        public int MeetingType { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
    }
}
