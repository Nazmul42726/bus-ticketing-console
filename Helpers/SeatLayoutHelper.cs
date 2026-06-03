namespace bus_ticketing_console.Helpers;

public class SeatLayoutHelper
{
    public void PrintSeatLayout(int totalSeats, List<string> reservedSeats)
    {
        Console.WriteLine("\nSeat Layout (Red = booked, Green = available):");
        switch (totalSeats)
        {
            case 28:
                SeatLayout28(reservedSeats);
                break;
            case 30:
                SeatLayout30(reservedSeats);
                break;
            case 32:
                SeatLayout32(reservedSeats);
                break;
            case 36:
                SeatLayout36(reservedSeats);
                break;
            case 40:
                SeatLayout40(reservedSeats);
                break;
            case 45:
                SeatLayout45(reservedSeats);
                break;            
        }
    }
    public void SeatLayout28(List<string> reservedSeats)
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
            Console.ForegroundColor = reservedSeats.Contains(seatA) ? ConsoleColor.Red : ConsoleColor.Green;
            Console.Write($"[{seatA}]".PadRight(5));
            Console.ResetColor();

            Console.Write("     "); // Aisle / Gangway spacing

            // Column B
            string seatB = $"{row}B";
            Console.ForegroundColor = reservedSeats.Contains(seatB) ? ConsoleColor.Red : ConsoleColor.Green;
            Console.Write($"[{seatB}]".PadRight(5));
            Console.ResetColor();

            // Column C
            string seatC = $"{row}C";
            Console.ForegroundColor = reservedSeats.Contains(seatC) ? ConsoleColor.Red : ConsoleColor.Green;
            Console.Write($"[{seatC}]".PadRight(5));
            Console.ResetColor();

            Console.WriteLine("│");
        }

        // Row 9: 4 seats across the back row
        Console.Write("  09  │ ");

        string seat9A = "9A";
        Console.ForegroundColor = reservedSeats.Contains(seat9A) ? ConsoleColor.Red : ConsoleColor.Green;
        Console.Write($"[{seat9A}]".PadRight(5));
        Console.ResetColor();

        string seat9E = "9E"; // Custom Extra Seat
        Console.ForegroundColor = reservedSeats.Contains(seat9E) ? ConsoleColor.Red : ConsoleColor.Green;
        Console.Write($"[{seat9E}]".PadRight(5));
        Console.ResetColor();

        string seat9B = "9B";
        Console.ForegroundColor = reservedSeats.Contains(seat9B) ? ConsoleColor.Red : ConsoleColor.Green;
        Console.Write($"[{seat9B}]".PadRight(5));
        Console.ResetColor();

        string seat9C = "9C";
        Console.ForegroundColor = reservedSeats.Contains(seat9C) ? ConsoleColor.Red : ConsoleColor.Green;
        Console.Write($"[{seat9C}]".PadRight(5));
        Console.ResetColor();

        Console.WriteLine("│");

        Console.WriteLine("      └─────────────────────┘");
        Console.WriteLine("      ║   [ REAR / BACK ]   ║");
        Console.WriteLine("      ╚═════════════════════╝");
    }

    public void SeatLayout30(List<string> reservedSeats)
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
            Console.ForegroundColor = reservedSeats.Contains(seatA) ? ConsoleColor.Red : ConsoleColor.Green;
            Console.Write($"[{seatA}]".PadRight(5));
            Console.ResetColor();

            // Aisle / Gangway spacing
            if(row < 10) Console.Write("     "); 
            else Console.Write("    ");

            // Column B
            string seatB = $"{row}B";
            Console.ForegroundColor = reservedSeats.Contains(seatB) ? ConsoleColor.Red : ConsoleColor.Green;
            Console.Write($"[{seatB}]".PadRight(5));
            Console.ResetColor();

            // Column C
            string seatC = $"{row}C";
            Console.ForegroundColor = reservedSeats.Contains(seatC) ? ConsoleColor.Red : ConsoleColor.Green;
            Console.Write($"[{seatC}]".PadRight(5));
            Console.ResetColor();

            if(row < 10) Console.WriteLine("│");
            else Console.WriteLine(" │");
        }

        Console.WriteLine("      └─────────────────────┘");
        Console.WriteLine("      ║   [ REAR / BACK ]   ║");
        Console.WriteLine("      ╚═════════════════════╝");
    }

    public void SeatLayout32(List<string> reservedSeats)
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
        Console.ForegroundColor = reservedSeats.Contains(seat1B) ? ConsoleColor.Red : ConsoleColor.Green;
        Console.Write($"[{seat1B}]".PadRight(5));
        Console.ResetColor();

        // Column C
        string seat1C = "1C";
        Console.ForegroundColor = reservedSeats.Contains(seat1C) ? ConsoleColor.Red : ConsoleColor.Green;
        Console.Write($"[{seat1C}]".PadRight(5));
        Console.ResetColor();

        Console.WriteLine("│");

        // Remaining 10 rows of [ A --- B C ] (Rows 2 to 11)
        for (int row = 2; row <= 11; row++)
        {
            Console.Write($"  {row:D2}  │ ");

            // Column A
            string seatA = $"{row}A";
            Console.ForegroundColor = reservedSeats.Contains(seatA) ? ConsoleColor.Red : ConsoleColor.Green;
            Console.Write($"[{seatA}]".PadRight(5));
            Console.ResetColor();

            // Aisle / Gangway spacing
            if(row < 10) Console.Write("     "); 
            else Console.Write("    "); 

            // Column B
            string seatB = $"{row}B";
            Console.ForegroundColor = reservedSeats.Contains(seatB) ? ConsoleColor.Red : ConsoleColor.Green;
            Console.Write($"[{seatB}]".PadRight(5));
            Console.ResetColor();

            // Column C
            string seatC = $"{row}C";
            Console.ForegroundColor = reservedSeats.Contains(seatC) ? ConsoleColor.Red : ConsoleColor.Green;
            Console.Write($"[{seatC}]".PadRight(5));
            Console.ResetColor();

            if(row < 10) Console.WriteLine("│"); 
            else Console.WriteLine(" │"); 
        }

        Console.WriteLine("      └─────────────────────┘");
        Console.WriteLine("      ║   [ REAR / BACK ]   ║");
        Console.WriteLine("      ╚═════════════════════╝");
    }

    public void SeatLayout36(List<string> reservedSeats)
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
            Console.ForegroundColor = reservedSeats.Contains(seatA) ? ConsoleColor.Red : ConsoleColor.Green;
            Console.Write($"[{seatA}]".PadRight(5));
            Console.ResetColor();

            // Column B
            string seatB = $"{row}B";
            Console.ForegroundColor = reservedSeats.Contains(seatB) ? ConsoleColor.Red : ConsoleColor.Green;
            Console.Write($"[{seatB}]".PadRight(5));
            Console.ResetColor();

            // Aisle
            Console.Write("   ");

            // Column C
            string seatC = $"{row}C";
            Console.ForegroundColor = reservedSeats.Contains(seatC) ? ConsoleColor.Red : ConsoleColor.Green;
            Console.Write($"[{seatC}]".PadRight(5));
            Console.ResetColor();

            // Column D
            string seatD = $"{row}D";
            Console.ForegroundColor = reservedSeats.Contains(seatD) ? ConsoleColor.Red : ConsoleColor.Green;
            Console.Write($"[{seatD}]".PadRight(5));
            Console.ResetColor();

            Console.WriteLine("│");
        }

        Console.WriteLine("      └────────────────────────┘");
        Console.WriteLine("      ║    [ REAR / BACK ]     ║");
        Console.WriteLine("      ╚════════════════════════╝");
    }

    public void SeatLayout40(List<string> reservedSeats)
    {
        Console.WriteLine("\n      ╔════════════════════════╗");
        Console.WriteLine("      ║   [ FRONT / ENGINE ]   ║");
        Console.WriteLine("      ╚════════════════════════╝");
        Console.WriteLine("          A    B       C    D");
        Console.WriteLine("      ┌────────────────────────┐");

        // 10 rows of [ A B --- C D ]
        for (int row = 1; row <= 10; row++)
        {
            Console.Write($"  {row:D2}  │ ");

            // Column A
            string seatA = $"{row}A";
            Console.ForegroundColor = reservedSeats.Contains(seatA) ? ConsoleColor.Red : ConsoleColor.Green;
            Console.Write($"[{seatA}]".PadRight(5));
            Console.ResetColor();

            // Column B
            string seatB = $"{row}B";
            Console.ForegroundColor = reservedSeats.Contains(seatB) ? ConsoleColor.Red : ConsoleColor.Green;
            Console.Write($"[{seatB}]".PadRight(5));
            Console.ResetColor();

            // Aisle
            if (row < 10) Console.Write("   ");
            else Console.Write("  ");

            // Column C
            string seatC = $"{row}C";
            Console.ForegroundColor = reservedSeats.Contains(seatC) ? ConsoleColor.Red : ConsoleColor.Green;
            Console.Write($"[{seatC}]".PadRight(5));
            Console.ResetColor();

            // Column D
            string seatD = $"{row}D";
            Console.ForegroundColor = reservedSeats.Contains(seatD) ? ConsoleColor.Red : ConsoleColor.Green;
            Console.Write($"[{seatD}]".PadRight(5));
            Console.ResetColor();

            if (row < 10) Console.WriteLine("│");
            else Console.WriteLine(" │");
        }

        Console.WriteLine("      └────────────────────────┘");
        Console.WriteLine("      ║    [ REAR / BACK ]     ║");
        Console.WriteLine("      ╚════════════════════════╝");
    }

    public void SeatLayout45(List<string> reservedSeats)
    {
        Console.WriteLine("\n      ╔═══════════════════════════╗");
        Console.WriteLine("      ║     [ FRONT / ENGINE ]    ║");
        Console.WriteLine("      ╚═══════════════════════════╝");
        Console.WriteLine("          A    B          C    D");
        Console.WriteLine("      ┌───────────────────────────┐");

        // 10 rows of [ A B --- C D ]
        for (int row = 1; row <= 11; row++)
        {
            Console.Write($"  {row:D2}  │ ");

            // Column A
            string seatA = $"{row}A";
            Console.ForegroundColor = reservedSeats.Contains(seatA) ? ConsoleColor.Red : ConsoleColor.Green;
            Console.Write($"[{seatA}]".PadRight(5));
            Console.ResetColor();

            // Column B
            string seatB = $"{row}B";
            Console.ForegroundColor = reservedSeats.Contains(seatB) ? ConsoleColor.Red : ConsoleColor.Green;
            Console.Write($"[{seatB}]".PadRight(5));
            Console.ResetColor();

            // Aisle
            if (row < 10) Console.Write("      ");
            else if(row == 10) Console.Write("     ");
            else if(row == 11){
                string seatExt = $"{row}E";
                Console.ForegroundColor = reservedSeats.Contains(seatA) ? ConsoleColor.Red : ConsoleColor.Green;
                Console.Write($"[{seatExt}]".PadRight(5));
                Console.ResetColor();
            }

            // Column C
            string seatC = $"{row}C";
            Console.ForegroundColor = reservedSeats.Contains(seatC) ? ConsoleColor.Red : ConsoleColor.Green;
            Console.Write($"[{seatC}]".PadRight(5));
            Console.ResetColor();

            // Column D
            string seatD = $"{row}D";
            Console.ForegroundColor = reservedSeats.Contains(seatD) ? ConsoleColor.Red : ConsoleColor.Green;
            Console.Write($"[{seatD}]".PadRight(5));
            Console.ResetColor();

            if (row < 10) Console.WriteLine("│");
            else Console.WriteLine(" │");
        }

        Console.WriteLine("      └───────────────────────────┘");
        Console.WriteLine("      ║      [ REAR / BACK ]      ║");
        Console.WriteLine("      ╚═══════════════════════════╝");
    }
}