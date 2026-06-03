namespace bus_ticketing_console.Helpers;

public class SeatLayoutHelper
{
    public void PrintSeatLayout(int totalSeats, List<string> bookedSeats, List<string> reservedSeats)
    {
        Console.WriteLine("\nSeat Layout (Red = booked, Green = available):");
        switch (totalSeats)
        {
            case 28:
                SeatLayout28(bookedSeats, reservedSeats);
                break;
            case 30:
                SeatLayout30(bookedSeats, reservedSeats);
                break;
            case 32:
                SeatLayout32(bookedSeats, reservedSeats);
                break;
            case 36:
                SeatLayout36(bookedSeats, reservedSeats);
                break;
            case 40:
                SeatLayout40(bookedSeats, reservedSeats);
                break;
            case 45:
                SeatLayout45(bookedSeats, reservedSeats);
                break;            
        }
    }
    public void SeatLayout28(List<string> bookedSeats, List<string> reservedSeats)
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

    public void SeatLayout30(List<string> bookedSeats, List<string> reservedSeats)
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

    public void SeatLayout32(List<string> bookedSeats, List<string> reservedSeats)
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

    public void SeatLayout36(List<string> bookedSeats, List<string> reservedSeats)
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

    public void SeatLayout40(List<string> bookedSeats, List<string> reservedSeats)
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
            if (row < 10) Console.Write("   ");
            else Console.Write("  ");

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

            if (row < 10) Console.WriteLine("│");
            else Console.WriteLine(" │");
        }

        Console.WriteLine("      └────────────────────────┘");
        Console.WriteLine("      ║    [ REAR / BACK ]     ║");
        Console.WriteLine("      ╚════════════════════════╝");
    }

    public void SeatLayout45(List<string> bookedSeats, List<string> reservedSeats)
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
            if (row < 10) Console.Write("      ");
            else if (row == 10) Console.Write("     ");
            else if (row == 11)
            {
                string seatExt = $"{row}E";
                if (reservedSeats.Contains(seatExt)) Console.ForegroundColor = ConsoleColor.Red;
                else if (bookedSeats.Contains(seatExt)) Console.ForegroundColor = ConsoleColor.Yellow;
                else Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"[{seatExt}]".PadRight(5));
                Console.ResetColor();
            }

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

            if (row < 10) Console.WriteLine("│");
            else Console.WriteLine(" │");
        }

        Console.WriteLine("      └───────────────────────────┘");
        Console.WriteLine("      ║      [ REAR / BACK ]      ║");
        Console.WriteLine("      ╚═══════════════════════════╝");
    }
}