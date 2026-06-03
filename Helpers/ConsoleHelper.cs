namespace bus_ticketing_console.Helpers;

public class ConsoleHelper
{
    public void PromptUser()
    {
        Console.Clear();

        // colors
        ConsoleColor primaryColor = ConsoleColor.Cyan;
        ConsoleColor groupColor = ConsoleColor.Yellow;
        ConsoleColor regularColor = ConsoleColor.White;
        ConsoleColor exitColor = ConsoleColor.Red;

        // 1. Header 
        Console.ForegroundColor = primaryColor;
        Console.WriteLine("╔══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                BUS TICKET BOOKING SYSTEM                 ║");
        Console.WriteLine("╠══════════════════════════════════════════════════════════╣");

        // 2. User Management Section
        Console.Write("║ ");
        Console.ForegroundColor = groupColor; Console.Write($"{"[ USER MANAGEMENT ]",-56}");
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
}