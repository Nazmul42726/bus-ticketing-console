namespace bus_ticketing_console.Interfaces;

public interface ISeatLayoutStrategy
{
    void PrintLayout(IReadOnlyList<string> reservedSeats, IReadOnlyList<string> bookedSeats);
}