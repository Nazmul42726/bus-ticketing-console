using bus_ticketing_console.Helpers;
using bus_ticketing_console.Interfaces;
using bus_ticketing_console.Models;

namespace bus_ticketing_console.Strategies;

public class SeatLayout45 : ISeatLayoutStrategy
{
    public void PrintLayout(IReadOnlyList<string> reservedSeats, IReadOnlyList<string> bookedSeats)
    {
        Console.WriteLine("\n      ╔═══════════════════════════╗");
        Console.WriteLine("      ║     [ FRONT / ENGINE ]    ║");
        Console.WriteLine("      ╚═══════════════════════════╝");
        Console.WriteLine("          A    B          C    D");
        Console.WriteLine("      ┌───────────────────────────┐");

        // 10 rows of [ A B --- C D ]
        for (int row = 1; row <= 11; row++)
        {
            string seatA = $"{row}A";
            string seatB = $"{row}B";
            string seatC = $"{row}C";
            string seatD = $"{row}D";

            Console.Write($"  {row:D2}  │ ");
            ConsoleHelper.PrintSeat(seatA, bookedSeats, reservedSeats);
            ConsoleHelper.PrintSeat(seatB, bookedSeats, reservedSeats);

            // Aisle
            if (row < 10) Console.Write("      ");
            else if (row == 10) Console.Write("     ");
            else if (row == 11)
            {
                string seatExt = $"{row}E";
                ConsoleHelper.PrintSeat(seatExt, bookedSeats, reservedSeats);
            }

            ConsoleHelper.PrintSeat(seatC, bookedSeats, reservedSeats);
            ConsoleHelper.PrintSeat(seatD, bookedSeats, reservedSeats);

            if (row < 10) Console.WriteLine("│");
            else Console.WriteLine(" │");
        }

        Console.WriteLine("      └───────────────────────────┘");
        Console.WriteLine("      ║      [ REAR / BACK ]      ║");
        Console.WriteLine("      ╚═══════════════════════════╝");
    }

    public bool IsValidSeat(string seat)=> SystemRegistry.Seats45.Contains(seat);

}
