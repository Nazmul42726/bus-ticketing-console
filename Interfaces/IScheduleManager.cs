using bus_ticketing_console.Models;

namespace bus_ticketing_console.Interfaces;

public interface IScheduleManager
{
    void CreateSchedule(Schedule schedule);
    List<Schedule> ShowSchedule();
    Schedule? GetScheduleDetails(string scheduleId);
}