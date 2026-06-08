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

        // Column B
        string seat1B = "1B";
        if (reservedSeats.Contains(seat1B)) Console.ForegroundColor = ConsoleColor.Red;
        else if (bookedSeats.Contains(seat1B)) Console.ForegroundColor = ConsoleColor.Yellow;
        else Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"[{seat1B}]".PadRight(5));
        Console.ResetColor();

        // Column C
        string seat1C = "1C";
        if (reservedSeats.Contains(seat1C)) Console.ForegroundColor = ConsoleColor.Red;
        else if (bookedSeats.Contains(seat1C)) Console.ForegroundColor = ConsoleColor.Yellow;
        else Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"[{seat1C}]".PadRight(5));
        Console.ResetColor();

        Console.WriteLine("│");

        // Remaining 10 rows of [ A --- B C ] (Rows 2 to 11)
        for (int row = 2; row <= 11; row++)
        {
            Console.Write($"  {row:D2}  │ ");

            // Column A
            string seatA = $"{row}A";
            if (reservedSeats.Contains(seatA)) Console.ForegroundColor = ConsoleColor.Red;
            else if (bookedSeats.Contains(seatA)) Console.ForegroundColor = ConsoleColor.Yellow;
            else Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"[{seatA}]".PadRight(5));
            Console.ResetColor();

            // Aisle / Gangway spacing
            if (row < 10) Console.Write("     "); 
            else Console.Write("    "); 

            // Column B
            string seatB = $"{row}B";
            if (reservedSeats.Contains(seatB)) Console.ForegroundColor = ConsoleColor.Red;
            else if (bookedSeats.Contains(seatB)) Console.ForegroundColor = ConsoleColor.Yellow;
            else Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"[{seatB}]".PadRight(5));
            Console.ResetColor();

            // Column C
            string seatC = $"{row}C";
            if (reservedSeats.Contains(seatC)) Console.ForegroundColor = ConsoleColor.Red;
            else if (bookedSeats.Contains(seatC)) Console.ForegroundColor = ConsoleColor.Yellow;
            else Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"[{seatC}]".PadRight(5));
            Console.ResetColor();

            if (row < 10) Console.WriteLine("│"); 
            else Console.WriteLine(" │"); 
        }

        Console.WriteLine("      └─────────────────────┘");
        Console.WriteLine("      ║   [ REAR / BACK ]   ║");
        Console.WriteLine("      ╚═════════════════════╝");
    }

    public bool IsValidSeat(string seat)=> SystemRegistry.Seats32.Contains(seat);

}
