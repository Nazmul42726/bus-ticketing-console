using bus_ticketing_console.Helpers;
using bus_ticketing_console.Interfaces;
using bus_ticketing_console.Models;

namespace bus_ticketing_console.Strategies;

public class SeatLayout36 : ISeatLayoutStrategy
{
    public void PrintLayout(IReadOnlyList<string> reservedSeats, IReadOnlyList<string> bookedSeats)
    {
        Console.WriteLine("\n      ╔════════════════════════╗");
        Console.WriteLine("      ║   [ FRONT / ENGINE ]   ║");
        Console.WriteLine("      ╚════════════════════════╝");
        Console.WriteLine("          A    B       C    D");
        Console.WriteLine("      ┌────────────────────────┐");

        // 9 rows of [ A B --- C D ]
        for (int row = 1; row <= 9; row++)
        {
            string seatA = $"{row}A";
            string seatB = $"{row}B";
            string seatC = $"{row}C";
            string seatD = $"{row}D";

            Console.Write($"  {row:D2}  │ ");
            ConsoleHelper.PrintSeat(seatA, bookedSeats, reservedSeats);
            ConsoleHelper.PrintSeat(seatB, bookedSeats, reservedSeats);

            // Aisle
            Console.Write("   ");

            ConsoleHelper.PrintSeat(seatC, bookedSeats, reservedSeats);
            ConsoleHelper.PrintSeat(seatD, bookedSeats, reservedSeats);

            Console.WriteLine("│");
        }

        Console.WriteLine("      └────────────────────────┘");
        Console.WriteLine("      ║    [ REAR / BACK ]     ║");
        Console.WriteLine("      ╚════════════════════════╝");
    }

    public bool IsValidSeat(string seat)=> SystemRegistry.Seats36.Contains(seat);
}
