namespace bus_ticketing_console.Models;

public class Schedule
{
    public string ScheduleId {get; set;} = string.Empty;
    public string CoachNumber {get; set;} = string.Empty;

    public required string DepartureCity {get; set;}
    public required string ArrivalCity {get; set;}

    public required string DepartureDateTime {get; set;}
    public required double TicketPrice {get; set;}
    public required Bus AssignedBus {get; set;}

    public List<string> ReservedSeats {get; set;} = new List<string>();
}