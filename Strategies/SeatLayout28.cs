using bus_ticketing_console.Helpers;
using bus_ticketing_console.Interfaces;
using bus_ticketing_console.Models;

namespace bus_ticketing_console.Strategies;

public class SeatLayout28 : ISeatLayoutStrategy
{
    public void PrintLayout(IReadOnlyList<string> reservedSeats, IReadOnlyList<string> bookedSeats)
    {
        Console.WriteLine("\n       ╔════════════════════╗");
        Console.WriteLine("       ║ [ FRONT / ENGINE ] ║");
        Console.WriteLine("       ╚════════════════════╝");
        Console.WriteLine("          A         B    C");
        Console.WriteLine("      ┌─────────────────────┐");

        // 8 rows of [ A --- B C ]
        for (int row = 1; row <= 8; row++)
        {
            string seatA = $"{row}A";
            string seatB = $"{row}B";
            string seatC = $"{row}C";

            Console.Write($"  {row:D2}  │ ");
            ConsoleHelper.PrintSeat(seatA, bookedSeats, reservedSeats);

            Console.Write("     "); // Aisle / Gangway spacing

            ConsoleHelper.PrintSeat(seatB, bookedSeats, reservedSeats);
            ConsoleHelper.PrintSeat(seatC, bookedSeats, reservedSeats);

            Console.WriteLine("│");
        }

        // Row 9: 4 seats across the back row
        Console.Write("  09  │ ");

        string seat9A = "9A";
        string seat9E = "9E"; // Custom Extra Seat
        string seat9B = "9B";
        string seat9C = "9C";
        ConsoleHelper.PrintSeat(seat9A, bookedSeats, reservedSeats);
        ConsoleHelper.PrintSeat(seat9E, bookedSeats, reservedSeats);
        ConsoleHelper.PrintSeat(seat9B, bookedSeats, reservedSeats);
        ConsoleHelper.PrintSeat(seat9C, bookedSeats, reservedSeats);

        Console.WriteLine("│");

        Console.WriteLine("      └─────────────────────┘");
        Console.WriteLine("      ║   [ REAR / BACK ]   ║");
        Console.WriteLine("      ╚═════════════════════╝");
    }

    public bool IsValidSeat(string seat)=> SystemRegistry.Seats28.Contains(seat);
}