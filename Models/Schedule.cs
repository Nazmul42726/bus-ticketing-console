namespace bus_ticketing_console.Models;

public class Schedule
{
    public string ScheduleId {get; set;} = string.Empty;
    public string CoachNumber {get; set;} = string.Empty;
    private readonly List<string> _bookedSeats = new();
    private readonly List<string> _reservedSeats = new();

    

    public required string DepartureCity {get; set;}
    public required string ArrivalCity {get; set;}

    public required DateTime DepartureDateTime {get; set;}
    public required double TicketPrice {get; set;}
    public required Bus AssignedBus {get; set;}
    public IReadOnlyList<string> BookedSeats => _bookedSeats.AsReadOnly();
    public void BookASeat(string newSeat)
    {
        //validation
        _bookedSeats.Add(newSeat);
        _reservedSeats.Remove(newSeat);
    }
    public IReadOnlyList<string> ReservedSeats => _reservedSeats.AsReadOnly();
    public void ReserveASeat(string newSeat)
    {
        //validation
        _reservedSeats.Add(newSeat);
    }


}