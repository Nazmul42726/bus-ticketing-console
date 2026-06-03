namespace bus_ticketing_console.Helpers;

public class ConsoleHelper
{
    public static void DisplayMainMenu()
    {
        Console.Clear();

        // Color configurations
        ConsoleColor primaryColor = ConsoleColor.Cyan;
        ConsoleColor groupColor = ConsoleColor.Yellow;
        ConsoleColor regularColor = Console.ForegroundColor;
        ConsoleColor exitColor = ConsoleColor.Red;

        // 1. Header 
        Console.ForegroundColor = primaryColor;
        Console.WriteLine("╔══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                 BUS TICKET BOOKING SYSTEM                ║");
        Console.WriteLine("╠══════════════════════════════════════════════════════════╣");

        // 2. User Management Section
        Console.ForegroundColor = regularColor;
        Console.Write("║ ");
        Console.ForegroundColor = groupColor; 
        Console.Write($"{"[ USER MANAGEMENT ]",-56}");
        Console.ForegroundColor = regularColor;
        Console.WriteLine(" ║");

        Console.WriteLine($"║ {"  1.  Create User",-27} {"2.  Show Users",-28} ║");
        Console.WriteLine($"║ {"",-56} ║");

        // 3. Fleet & Operations Section
        Console.Write("║ "); 
        Console.ForegroundColor = groupColor; 
        Console.Write($"{"[ FLEET & OPERATIONS ]",-56}"); 
        Console.ForegroundColor = regularColor;
        Console.WriteLine(" ║");

        Console.WriteLine($"║ {"  3.  Create Bus",-27} {"4.  Show Buses",-28} ║");
        Console.WriteLine($"║ {"  5.  Create Schedule",-27} {"6.  Show Schedules",-28} ║");
        Console.WriteLine($"║ {"  7.  Show Schedule Details",-56} ║");
        Console.WriteLine($"║ {"",-56} ║");

        // 4. Ticketing & Billing Section
        Console.Write("║ "); 
        Console.ForegroundColor = groupColor; 
        Console.Write($"{"[ TICKETING & BILLING ]",-56}"); 
        Console.ForegroundColor = regularColor; 
        Console.WriteLine(" ║");

        Console.WriteLine($"║ {"  8.  Book Ticket",-27} {"9.  Show Invoices of a User",-28} ║");
        Console.WriteLine($"║ {"  10. Pay Invoice",-27} {"11. Show Tickets of a User",-28} ║");
        Console.WriteLine($"║ {"",-56} ║");

        // 5. Exit Section
        Console.Write("║ "); 
        Console.ForegroundColor = exitColor; 
        Console.Write($"{"  12. Exit",-56}"); 
        Console.ForegroundColor = regularColor; 
        Console.WriteLine(" ║");

        // 6. Footer Closing
        Console.WriteLine("╚══════════════════════════════════════════════════════════╝");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Enter your choice (1-12): ");
        Console.ResetColor();
    }

    public static void DisplayTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title)) return;

        string upperTitle = title.ToUpper().Trim();

        int minInnerWidth = 58;

        int textWidthWithPadding = upperTitle.Length + 4;

        int innerWidth = Math.Max(minInnerWidth, textWidthWithPadding);

        int totalPaddingSpaces = innerWidth - upperTitle.Length;
        int leftPadding = totalPaddingSpaces / 2;
        int rightPadding = totalPaddingSpaces - leftPadding;

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine();
        // 1. Top Border
        Console.Write("╔");
        Console.Write(new string('═', innerWidth));
        Console.WriteLine("╗");

        // 2. Centered Title Line
        Console.Write("║");
        Console.Write(new string(' ', leftPadding));
        Console.Write(upperTitle);
        Console.Write(new string(' ', rightPadding));
        Console.WriteLine("║");

        // 3. Bottom Border
        Console.Write("╚");
        Console.Write(new string('═', innerWidth));
        Console.WriteLine("╝");

        Console.ResetColor();
        Console.WriteLine(); 
    }

    public static void Prompt(string promptToShow)
    {
        int totalLength = 25; 

        Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write("» ");
        Console.ForegroundColor = ConsoleColor.White;    

        string formattedLabel = promptToShow.PadRight(totalLength)+" : ";
        Console.Write(formattedLabel);
        
        Console.ForegroundColor = ConsoleColor.Cyan;
    }

    public static void SuccessMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"[✓] {message}!");
        Console.ResetColor();
    }

    public static void CautionMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"[!] {message}!");
        Console.ResetColor();
    }

    public static void ErrorMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"[X] {message}!");
        Console.ResetColor();
    }

    public static void DisplayTable(string[] headers, List<string[]> rows)
    {
        if (headers == null || headers.Length == 0) return;

        int columnCount = headers.Length;
        int[] columnWidths = new int[columnCount];
        int paddingBuffer = 4; 

        // 1. Calculate Maximum Width for each column
        for (int i = 0; i < columnCount; i++)
        {
            columnWidths[i] = headers[i].Length;
        }

        foreach (var row in rows)
        {
            // Safeguard against short rows to prevent IndexOutOfRangeException
            int cellsToProcess = Math.Min(columnCount, row.Length);
            for (int i = 0; i < cellsToProcess; i++)
            {
                columnWidths[i] = Math.Max(columnWidths[i], row[i].Length);
            }
        }

        // Add padding buffer to the calculated widths
        for (int j = 0; j < columnCount; j++)
        {
            columnWidths[j] += paddingBuffer;
        }

        // 2. Draw Top Border Block
        DrawBorderLine('┌', '┬', '┐', columnWidths);

        // 3. Render Centered Headers Line
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("│");
        for (int j = 0; j < columnCount; j++)
        {
            Console.Write(CenterText(headers[j], columnWidths[j]) + "│");
        }
        Console.WriteLine();
        Console.ResetColor();

        // 4. Draw Divider Line below Header
        DrawBorderLine('├', '┼', '┤', columnWidths);

        // 5. Render Data Rows
        foreach (var row in rows)
        {
            Console.Write("│");
            for (int j = 0; j < columnCount; j++)
            {
                string cellText = j < row.Length ? row[j] : "";
                string paddedCell = ("  " + cellText).PadRight(columnWidths[j]);
                Console.Write(paddedCell + "│");
            }
            Console.WriteLine();
        }

        // 6. Draw Bottom Border Block
        DrawBorderLine('└', '┴', '┘', columnWidths);
    }

    private static void DrawBorderLine(char leftChar, char intersectionChar, char rightChar, int[] widths)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write(leftChar);
        for (int i = 0; i < widths.Length; i++)
        {
            Console.Write(new string('─', widths[i]));
            if (i < widths.Length - 1) Console.Write(intersectionChar);
        }
        Console.WriteLine(rightChar);
        Console.ResetColor();
    }

    private static string CenterText(string text, int width)
    {
        if (string.IsNullOrEmpty(text)) return new string(' ', width);
        
        int totalSpaces = width - text.Length;
        int leftPadding = totalSpaces / 2;
        int rightPadding = totalSpaces - leftPadding;

        return new string(' ', leftPadding) + text + new string(' ', rightPadding);
    }
}