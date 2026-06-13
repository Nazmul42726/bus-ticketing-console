using bus_ticketing_console.Helpers;
using bus_ticketing_console.Interfaces;
using bus_ticketing_console.Models;

namespace bus_ticketing_console.Strategies;

public class SeatLayout32 : ISeatLayoutStrategy
{
    public void PrintLayout(IReadOnlyList<string> reservedSeats, IReadOnlyList<string> bookedSeats)
    {
        Console.WriteLine("\n       ╔════════════════════╗");
        Console.WriteLine("       ║ [ FRONT / ENGINE ] ║");
        Console.WriteLine("       ╚════════════════════╝");
        Console.WriteLine("          A         B    C");
        Console.WriteLine("      ┌─────────────────────┐");

        // Row 1: Front cabin layout [--   B C] (Empty space on column A side)
        Console.Write("  01  │ ");
        Console.Write("     "); // Empty spacing block matching a PadRight(5) seat slot
        Console.Write("     "); // Aisle / Gangway spacing

        string seat1B = "1B";
        string seat1C = "1C";
        ConsoleHelper.PrintSeat(seat1B, bookedSeats, reservedSeats);
        ConsoleHelper.PrintSeat(seat1C, bookedSeats, reservedSeats);

        Console.WriteLine("│");

        // Remaining 10 rows of [ A --- B C ] (Rows 2 to 11)
        for (int row = 2; row <= 11; row++)
        {
            string seatA = $"{row}A";
            string seatB = $"{row}B";
            string seatC = $"{row}C";

            Console.Write($"  {row:D2}  │ ");
            ConsoleHelper.PrintSeat(seatA, bookedSeats, reservedSeats);

            // Aisle / Gangway spacing
            if (row < 10) Console.Write("     "); 
            else Console.Write("    "); 

            ConsoleHelper.PrintSeat(seatB, bookedSeats, reservedSeats);
            ConsoleHelper.PrintSeat(seatC, bookedSeats, reservedSeats);

            if (row < 10) Console.WriteLine("│"); 
            else Console.WriteLine(" │"); 
        }

        Console.WriteLine("      └─────────────────────┘");
        Console.WriteLine("      ║   [ REAR / BACK ]   ║");
        Console.WriteLine("      ╚═════════════════════╝");
    }

    public bool IsValidSeat(string seat)=> SystemRegistry.Seats32.Contains(seat);
}
