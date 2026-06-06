using bus_ticketing_console.Interfaces;

namespace bus_ticketing_console.Strategies;

public class SeatLayout30 : ISeatLayoutStrategy
{
    public void PrintLayout(IReadOnlyList<string> reservedSeats, IReadOnlyList<string> bookedSeats)
    {
        Console.WriteLine("\n       ╔════════════════════╗");
        Console.WriteLine("       ║ [ FRONT / ENGINE ] ║");
        Console.WriteLine("       ╚════════════════════╝");
        Console.WriteLine("          A         B    C");
        Console.WriteLine("      ┌─────────────────────┐");

        // 10 rows of [ A --- B C ]
        for (int row = 1; row <= 10; row++)
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
}