using ChilliSoftAssessmentMeetingMinuteTakerDLL.Dtos;
using Microsoft.AspNetCore.SignalR;

namespace ChilliSoftAssessmentMeetingMinuteTakerMVC.Hubs;
public class MeetingHub : Hub
{
    public Task SendMessage(SignalRMessage message) {

        return Clients.All.SendAsync(method:"RecieveMessage",message);
    }
}
