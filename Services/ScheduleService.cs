using bus_ticketing_console.Interfaces;
using bus_ticketing_console.Models;

namespace bus_ticketing_console.Services;

public class ScheduleService : IScheduleManager
{
    private readonly List<Schedule> _scheduleList = new List<Schedule>();
    private int _totalSchedule = 0;
    public void CreateSchedule(Schedule schedule)
    {
        string ACStatus;
        if(schedule.AssignedBus.IsAirConditioned) ACStatus = "AC";
        else ACStatus = "NonAC";

        schedule.ScheduleId = $"SDL-{_totalSchedule:X3}";
        schedule.CoachNumber = $"Coach: {_totalSchedule:X4}-{ACStatus}"; //will assign totalSchedule of that day instead totalSchedule
        _scheduleList.Add(schedule);
        _totalSchedule++;
    }
    public List<Schedule> ShowSchedule()
    {
        return _scheduleList;
    }
    public Schedule? GetScheduleDetails(string scheduleId)
    {
        return _scheduleList.FirstOrDefault(s => s.ScheduleId == scheduleId);
    }
}