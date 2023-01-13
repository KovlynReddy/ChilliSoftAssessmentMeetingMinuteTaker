using ChilliSoftAssessmentMeetingMinuteTakerAPI.Data.DataAccess.Interfaces;
using ChilliSoftAssessmentMeetingMinuteTakerAPI.Data.DataAccess.Repositories;
using ChilliSoftAssessmentMeetingMinuteTakerMVC.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("MeetingDBConnection");
builder.Services.AddDbContext<MeetingDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddTransient<IMeetingDB, MeetingDB>();
builder.Services.AddTransient<IMeetingItemDB, MeetingItemDB>();
builder.Services.AddTransient<IMeetingMinutesDB, MeetingMinuteDB>();
builder.Services.AddTransient<IUserDB, UserDB>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
