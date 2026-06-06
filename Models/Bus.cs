using bus_ticketing_console.Interfaces;

namespace bus_ticketing_console.Models;

public class Bus
{
    public string BusId { get; set; } = string.Empty;
    public required string ModelName { get; set; }
    public required string Classification { get; set; }
    public required int TotalCapacity { get; set; }
    public required bool IsAirConditioned { get; set; }
    public bool IsAvailable { get; set; } = true;

    public required ISeatLayoutStrategy LayoutStrategy {get; set;}
    public void ShowSeatLayout(IReadOnlyList<string> reservedSeats, IReadOnlyList<string> bookedSeats)
    {
        LayoutStrategy.PrintLayout(reservedSeats, bookedSeats);
    }
}