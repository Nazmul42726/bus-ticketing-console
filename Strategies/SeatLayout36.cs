using bus_ticketing_console.Interfaces;

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
            Console.Write($"  {row:D2}  │ ");

            // Column A
            string seatA = $"{row}A";
            if (reservedSeats.Contains(seatA)) Console.ForegroundColor = ConsoleColor.Red;
            else if (bookedSeats.Contains(seatA)) Console.ForegroundColor = ConsoleColor.Yellow;
            else Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"[{seatA}]".PadRight(5));
            Console.ResetColor();

            // Column B
            string seatB = $"{row}B";
            if (reservedSeats.Contains(seatB)) Console.ForegroundColor = ConsoleColor.Red;
            else if (bookedSeats.Contains(seatB)) Console.ForegroundColor = ConsoleColor.Yellow;
            else Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"[{seatB}]".PadRight(5));
            Console.ResetColor();

            // Aisle
            Console.Write("   ");

            // Column C
            string seatC = $"{row}C";
            if (reservedSeats.Contains(seatC)) Console.ForegroundColor = ConsoleColor.Red;
            else if (bookedSeats.Contains(seatC)) Console.ForegroundColor = ConsoleColor.Yellow;
            else Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"[{seatC}]".PadRight(5));
            Console.ResetColor();

            // Column D
            string seatD = $"{row}D";
            if (reservedSeats.Contains(seatD)) Console.ForegroundColor = ConsoleColor.Red;
            else if (bookedSeats.Contains(seatD)) Console.ForegroundColor = ConsoleColor.Yellow;
            else Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"[{seatD}]".PadRight(5));
            Console.ResetColor();

            Console.WriteLine("│");
        }

        Console.WriteLine("      └────────────────────────┘");
        Console.WriteLine("      ║    [ REAR / BACK ]     ║");
        Console.WriteLine("      ╚════════════════════════╝");
    }
}
