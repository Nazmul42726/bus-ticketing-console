using bus_ticketing_console.Interfaces;
using bus_ticketing_console.Strategies;

namespace bus_ticketing_console.Helpers;

public static class SeatLayoutFactory
{
    public static ISeatLayoutStrategy CreateStrategy(int capacity)
    {
        return capacity switch
        {
            28 => new SeatLayout28(),
            30 => new SeatLayout30(),
            32 => new SeatLayout32(),
            36 => new SeatLayout36(),
            40 => new SeatLayout40(),
            45 => new SeatLayout45(),
            _ => throw new ArgumentException($"No layout strategy found for capacity: {capacity}")
        };
    }
}