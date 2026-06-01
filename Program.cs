using bus_ticketing_console.Interfaces;
using bus_ticketing_console.Models;
using bus_ticketing_console.Services;

namespace bus_ticketing_console;

class Program
{
    static IUserManager userManager = new UserService();
    static IBusManager busManager = new BusService();
    static void Main()
    {
        while (true)
        {
            PromptUser();

            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CreateNewUser();
                    break;
                case "2":
                    ShowAllUser();
                    break;
                case "3":
                    CreateNewBus();
                    break;
                case "4":
                    ShowAllBus();
                    break;
                case "12":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Goodbye!");
                    Console.ResetColor();
                    return;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice!");
                    Console.ResetColor();
                    WaitForInput();
                    break;
                    
            }
        }
    }
    static void PromptUser()
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

        Console.WriteLine($"║ {"  1. Create User",-27} {"2. Show Users",-28} ║");
        Console.WriteLine($"║ {"",-56} ║");

        // 3. Fleet & Operations Section
        Console.Write("║ "); 
        Console.ForegroundColor = groupColor; 
        Console.Write($"{"[ FLEET & OPERATIONS ]",-56}"); 
        Console.ForegroundColor = regularColor;
        Console.WriteLine(" ║");

        Console.WriteLine($"║ {"  3. Create Bus",-27} {"4. Show Buses",-28} ║");
        Console.WriteLine($"║ {"  5. Create Schedule",-27} {"6. Show Schedules",-28} ║");
        Console.WriteLine($"║ {"  7. Show Schedule Details",-56} ║");
        Console.WriteLine($"║ {"",-56} ║");

        // 4. Ticketing & Billing Section
        Console.Write("║ "); 
        Console.ForegroundColor = groupColor; 
        Console.Write($"{"[ TICKETING & BILLING ]",-56}"); 
        Console.ForegroundColor = regularColor; 
        Console.WriteLine(" ║");

        Console.WriteLine($"║ {"  8. Book Ticket",-27} {"9. Show Invoices of a User",-28} ║");
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

    static void CreateNewUser()
    {
        Console.Write("» Enter User Name      : ");
        string name = Console.ReadLine() ?? "";

        Console.Write("» Enter Mobile Number  : ");
        string mobile = Console.ReadLine() ?? "";

        Console.Write("» Enter Email Address  : ");
        string email = Console.ReadLine() ?? "";

        User NewUser = new User
        {
            UserName = name,
            MobileNumber = mobile,
            Email = email
        };

        userManager.CreateUser(NewUser);

        Console.WriteLine("User Created Successfully!");
        WaitForInput();
    }
    static void ShowAllUser()
    {
        List<User> AllUser = userManager.ShowUsers();
        foreach (User user in AllUser)
        {
            Console.WriteLine($"ID -> {user.UserId}, Name -> {user.UserName}");
        }
        WaitForInput();
    }

    static void CreateNewBus()
    {
        Console.WriteLine("\n» Bus Model:");
        Console.WriteLine("  1. Scania Multi-Axle      2. Hino 1J");
        Console.WriteLine("  3. Hyundai Universe       4. Volvo B11R");
        Console.WriteLine("  5. Ashok Leyland          6. Isuzu Turkuaz");
        Console.Write("Select Bus Model: ");
        string modelChoice = Console.ReadLine() ?? "";
        string modelName = modelChoice switch
        {
            "1" => "Scania Multi-Axle",
            "2" => "Hino 1J",
            "3" => "Hyundai Universe",
            "4" => "Volvo B11R",
            "5" => "Ashok Leyland",
            "6" => "Isuzu Turkuaz",
            _ => "Standard Fleet Bus" 
        };

        Console.WriteLine("\n» Bus Classification:");
        Console.WriteLine("  1. Business Class         2. Economy Class");
        Console.Write("Select Bus Classification: ");
        string classChoice = Console.ReadLine() ?? "";
        string classification = classChoice switch
        {
            "1" => "Business",
            "2" => "Economy",
            _ => "Economy"
        };

        int totalCapacity = 40; 

        if(classification == "Business"){
            Console.WriteLine("\n» Seating Capacity:");
            Console.WriteLine("  1. 28 Seats [Ultra Luxury]");
            Console.WriteLine("  2. 30 Seats [Executive]");
            Console.WriteLine("  3. 32 Seats [Standard]");
            Console.Write("Select Seating Capacity: ");
            string capacityChoice = Console.ReadLine() ?? "";
            
            totalCapacity = capacityChoice switch
            {
                "1" => 28,
                "2" => 30,
                "3" => 32,
                _ => 30 
            };
        }
        else{
            Console.WriteLine("\n» Seating Capacity:");
            Console.WriteLine("  1. 36 Seats [Spacious]");
            Console.WriteLine("  2. 40 Seats [Standard Comfort]");
            Console.WriteLine("  3. 45 Seats [High Capacity]");
            Console.Write("Select Seating Capacity: ");
            string capacityChoice = Console.ReadLine() ?? "";
            
            totalCapacity = capacityChoice switch
            {
                "1" => 36,
                "2" => 40,
                "3" => 45,
                _ => 40 
            };
        }

        Console.WriteLine("\n» Is this an Air-Conditioned (AC) Bus?");
        Console.WriteLine("  1. Yes [AC]             2. No [Non-AC]");
        Console.Write("Selected Status: ");
        string acChoice = Console.ReadLine() ?? "";
        bool isAirConditioned = acChoice == "1";

        Bus NewBus = new Bus
        {
            ModelName = modelName,
            Classification = classification,
            TotalCapacity = totalCapacity,
            IsAirConditioned = isAirConditioned
        };

        busManager.CreateBus(NewBus);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nBus Registered Successfully!");
        Console.ResetColor();
        WaitForInput();
    }

    static void ShowAllBus()
    {
        List<Bus> AllBuses = busManager.ShowBuses();
        
        if(AllBuses.Count == 0){
            Console.WriteLine("No buses registered in the system yet.");
        }
        else{
            foreach (Bus bus in AllBuses)
            {
                string acStatus = bus.IsAirConditioned ? "AC" : "Non-AC";
                string availability = bus.IsAvailable ? "Available" : "On Trip / Not Fit";

                Console.WriteLine($"ID -> {bus.BusId} | {bus.ModelName} ({bus.Classification} - {acStatus}) | Seats: {bus.TotalCapacity} | Status: {availability}");
            }
        }
        WaitForInput();
    }
    static void WaitForInput()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}