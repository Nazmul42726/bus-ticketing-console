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
            Console.Write($"  {row:D2}  │ ");

            // Column A
            string seatA = $"{row}A";
            if (reservedSeats.Contains(seatA)) Console.ForegroundColor = ConsoleColor.Red;
            else if (bookedSeats.Contains(seatA)) Console.ForegroundColor = ConsoleColor.Yellow;
            else Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"[{seatA}]".PadRight(5));
            Console.ResetColor();

            Console.Write("     "); // Aisle / Gangway spacing

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

            Console.WriteLine("│");
        }

        // Row 9: 4 seats across the back row
        Console.Write("  09  │ ");

        string seat9A = "9A";
        if (reservedSeats.Contains(seat9A)) Console.ForegroundColor = ConsoleColor.Red;
        else if (bookedSeats.Contains(seat9A)) Console.ForegroundColor = ConsoleColor.Yellow;
        else Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"[{seat9A}]".PadRight(5));
        Console.ResetColor();

        string seat9E = "9E"; // Custom Extra Seat
        if (reservedSeats.Contains(seat9E)) Console.ForegroundColor = ConsoleColor.Red;
        else if (bookedSeats.Contains(seat9E)) Console.ForegroundColor = ConsoleColor.Yellow;
        else Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"[{seat9E}]".PadRight(5));
        Console.ResetColor();

        string seat9B = "9B";
        if (reservedSeats.Contains(seat9B)) Console.ForegroundColor = ConsoleColor.Red;
        else if (bookedSeats.Contains(seat9B)) Console.ForegroundColor = ConsoleColor.Yellow;
        else Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"[{seat9B}]".PadRight(5));
        Console.ResetColor();

        string seat9C = "9C";
        if (reservedSeats.Contains(seat9C)) Console.ForegroundColor = ConsoleColor.Red;
        else if (bookedSeats.Contains(seat9C)) Console.ForegroundColor = ConsoleColor.Yellow;
        else Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"[{seat9C}]".PadRight(5));
        Console.ResetColor();

        Console.WriteLine("│");

        Console.WriteLine("      └─────────────────────┘");
        Console.WriteLine("      ║   [ REAR / BACK ]   ║");
        Console.WriteLine("      ╚═════════════════════╝");
    }

    public bool IsValidSeat(string seat)=> SystemRegistry.Seats28.Contains(seat);
}