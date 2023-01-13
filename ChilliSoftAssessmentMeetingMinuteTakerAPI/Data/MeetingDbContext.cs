using ChilliSoftAssessmentMeetingMinuteTakerDLL.DomainModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChilliSoftAssessmentMeetingMinuteTakerMVC.Data
{
    public class MeetingDbContext : IdentityDbContext
    {
        public MeetingDbContext(DbContextOptions<MeetingDbContext> options)
            : base(options)
        {
        }

        public DbSet<Item> MeetingItems { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<User> MeetingUsers { get; set; }
        public DbSet<Minutes> MeetingMinutes { get; set; }
        public DbSet<MeetingType> MeetingTypes { get; set; }
        public DbSet<ItemStatus> ItemStatis { get; set; }
    }
}