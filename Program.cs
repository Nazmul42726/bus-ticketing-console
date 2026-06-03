using bus_ticketing_console.Interfaces;
using bus_ticketing_console.Models;
using bus_ticketing_console.Services;
using bus_ticketing_console.Helpers;

namespace bus_ticketing_console;

class Program
{
    static ConsoleHelper    consoleHelper    = new ConsoleHelper();
    static SeatLayoutHelper seatLayoutHelper = new SeatLayoutHelper();
    static IUserManager     userManager      = new UserService();
    static IBusManager      busManager       = new BusService();
    static IScheduleManager scheduleManager  = new ScheduleService();
    static IBookingManager  bookingManager   = new BookingService();

    static void Main()
    {
        while (true)
        {
            consoleHelper.PromptUser();

            string? input = Console.ReadLine();
            List<string> dummy = new List<string>();
            
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
                case "5":
                    CreateNewSchedule();
                    break;
                case "6":
                    ShowAllSchedule();
                    break;
                case "7":
                    ShowScheduleDetails();
                    break;
                case "8":
                    BookingTicket();
                    break;
                case "9":
                    ShowUserInvoices();
                    break;
                case "10":
                    PayInvoice();
                    break;
                case "11":
                    ShowUserTickets();
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

    static void CreateNewSchedule()
    {
        List<Bus> availableBuses = busManager.ShowAvailableBuses();
        if(availableBuses.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nNo buses available!");
            Console.ResetColor();
            WaitForInput();
            return;
        }
        Console.WriteLine("\n» Available Buses for this Schedule:");
        for(int i=0; i<availableBuses.Count; i++)
        {
            Bus bus = availableBuses[i];
            string ACStatus;
            if(bus.IsAirConditioned) ACStatus = "AC";
            else ACStatus = "Non-AC";

            Console.WriteLine($"{i+1} | Model: {bus.ModelName} | Class: {bus.Classification} | Capacity: {bus.TotalCapacity} | {ACStatus}");
        }

        int busIndex;
        while (true)
        {
            Console.WriteLine($"Selected Bus(1-{availableBuses.Count}): ");

            if(int.TryParse(Console.ReadLine(), out int idx) && idx >= 1 && idx <= availableBuses.Count)
            {
                busIndex = idx - 1;
                break;
            }
            Console.WriteLine($"Invalid Selection!"); //no escape option, either complete or stuck in infinite loop. will fix it.
        }

        Bus selectedBus = availableBuses[busIndex];

        string[] cities = { 
            "Dhaka", 
            "Chattogram", 
            "Cox's Bazar", 
            "Sylhet", 
            "Rajshahi", 
            "Khulna", 
            "Barishal", 
            "Rangpur", 
            "Mymensingh", 
            "Cumilla", 
            "Bogura", 
            "Jashore" 
        };

        int departureCityIdx;
        int arrivalCityIdx;

        while (true)
        {
            Console.WriteLine("\n» Departure City:");
            for(int i=0; i<cities.Length; i++)
            {
                Console.WriteLine($"{i+1}: {cities[i]}");
            }
            Console.WriteLine("\n» Selected Departure City:");
            if(int.TryParse(Console.ReadLine(), out int depIdx) && depIdx >= 1 && depIdx <= cities.Length){
                departureCityIdx = depIdx-1;
                break;
            }
            Console.WriteLine("Invalid city selection!");
        }

        while (true)
        {
            Console.WriteLine("\n» Arrival City:");
            int counter = 1;
            for(int i=0; i<cities.Length; i++)
            {
                if(i != departureCityIdx){
                    Console.WriteLine($"{counter}: {cities[i]}");
                    counter++;
                }
            }
            Console.WriteLine("\n» Selected Arrival City:");
            if(int.TryParse(Console.ReadLine(), out int arvIdx) && arvIdx >= 1 && arvIdx < cities.Length){
                if(arvIdx-1 >= departureCityIdx) arvIdx++;
                arrivalCityIdx = arvIdx-1;
                break;
            }
            Console.WriteLine("Invalid city selection!");
        }

        Console.WriteLine("\n» Enter Schedule Date and Time Details:");
        int day, month, hour, minute;

        while (true)
        {
            Console.Write("  Enter Month (1-12): ");
            if (int.TryParse(Console.ReadLine(), out month) && month >= 1 && month <= 12) break;
            Console.WriteLine("  Invalid month!");
        }

        while (true)
        {
            Console.Write("  Enter Day (1-31): ");
            if (int.TryParse(Console.ReadLine(), out day) && day >= 1 && day <= 31) break; // February 31 can be selected, lol, will fix later
            Console.WriteLine("  Invalid day!");
        }

        while (true)
        {
            Console.Write("  Enter Hour (0-23, 24-Hour Format): ");
            if (int.TryParse(Console.ReadLine(), out hour) && hour >= 0 && hour <= 23) break;
            Console.WriteLine("  Invalid hour!");
        }

        while (true)
        {
            Console.Write("  Enter Minute (0-59): ");
            if (int.TryParse(Console.ReadLine(), out minute) && minute >= 0 && minute <= 59) break;
            Console.WriteLine("  Invalid minute!");
        }

        string formattedDateTime = $"2026-{month:D2}-{day:D2} {hour:D2}:{minute:D2}"; //only 2026? scheduling in past is possible? fix later

        double confirmedPrice = 0;
        while (true)
        {
            Console.Write("\n» Enter Ticket Price (BDT): ");
            string firstInput = Console.ReadLine() ?? "";
            
            if (!double.TryParse(firstInput, out double firstPrice) || firstPrice <= 0)
            {
                Console.WriteLine("Price must be a valid number greater than 0.");
                continue;
            }

            Console.Write("» Re-enter Ticket Price to Confirm: ");
            string secondInput = Console.ReadLine() ?? "";
            
            if (double.TryParse(secondInput, out double secondPrice) && firstPrice == secondPrice)
            {
                confirmedPrice = firstPrice;
                break;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: Prices do not match or input was invalid! Try again.");
            Console.ResetColor();
        }

        Schedule newSchedule = new Schedule
        {
            DepartureCity     = cities[departureCityIdx],
            ArrivalCity       = cities[arrivalCityIdx],
            DepartureDateTime = formattedDateTime,
            TicketPrice       = confirmedPrice,
            AssignedBus       = selectedBus
        };

        scheduleManager.CreateSchedule(newSchedule);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n Schedule Created Successfully!\n From: {cities[departureCityIdx]}\n To: {cities[arrivalCityIdx]}\n Time: {formattedDateTime}");
        Console.ResetColor();
        WaitForInput();
    }

    static void ShowAllSchedule()
    {
        List<Schedule> AllSchedules = scheduleManager.ShowSchedule();
        
        if(AllSchedules.Count == 0){
            Console.WriteLine("No schedules registered in the system yet.");
        }
        else{
            foreach (Schedule schedule in AllSchedules)
            {
                Console.WriteLine($"ID -> {schedule.ScheduleId} | {schedule.DepartureCity} - {schedule.ArrivalCity} | {schedule.DepartureDateTime} | {schedule.TicketPrice} BDT | {schedule.AssignedBus.TotalCapacity - schedule.ReservedSeats.Count} Seats Available");
            }
        }
        WaitForInput();
    }

    static void ShowScheduleDetails()
    {
        Console.Write("\nEnter Schedule ID: ");
        string inputId = Console.ReadLine() ?? "";

        Schedule? schedule = scheduleManager.GetScheduleDetails(inputId);

        if (schedule == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: Invalid Schedule ID!");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine($"\n[ Schedule ID: {schedule.ScheduleId} ]");
            Console.WriteLine($"Coach Number : {schedule.CoachNumber}");
            Console.WriteLine($"Route        : {schedule.DepartureCity} -> {schedule.ArrivalCity}");
            Console.WriteLine($"Departure    : {schedule.DepartureDateTime}");
            Console.WriteLine($"Ticket Price : {schedule.TicketPrice} BDT");
            Console.WriteLine($"Assigned Bus : {schedule.AssignedBus.ModelName} ({schedule.AssignedBus.Classification})");
            seatLayoutHelper.PrintSeatLayout(schedule.AssignedBus.TotalCapacity, schedule.ReservedSeats);
        }

        WaitForInput();
    }

    static void BookingTicket()
    {
        Console.Write("\nEnter User ID: ");
        string userId = Console.ReadLine() ?? ""; //validate later

        ShowAllSchedule(); //todo: show based on departure and arrival city

        Console.Write("\nSelected Schedule ID: ");
        string scheduleId = Console.ReadLine() ?? ""; //validate later also take the idx as input, like selecting city in schedule creation

        Schedule? selectedSchedule = scheduleManager.GetScheduleDetails(scheduleId);

        seatLayoutHelper.PrintSeatLayout(selectedSchedule.AssignedBus.TotalCapacity,        selectedSchedule.ReservedSeats);

        Console.Write("\nSelected Seat: ");
        string selectedSeat = Console.ReadLine() ?? ""; //validate later

        Invoice newInvoice = new Invoice
        {
            UserId = userId,
            ScheduleId = scheduleId,
            SelectedSeat = selectedSeat
        };

        //a seat can be booked multiple time now, will fix it
        bookingManager.BookATicket(newInvoice);
    }

    static void ShowUserInvoices()
    {
        Console.Write("\nEnter User ID: ");
        string userId = Console.ReadLine() ?? ""; //validate later

        List<Invoice> userInvoices = new List<Invoice>();
        userInvoices = bookingManager.UserInvoice(userId);

        foreach (Invoice invoice in userInvoices)
        {
            Console.WriteLine($"Invoice ID: {invoice.InvoiceId}"); //format output later
        }
    }

    static void PayInvoice()
    {
        Console.Write("\nEnter Invoice ID: ");
        string invoiceId = Console.ReadLine() ?? ""; //validate later

        bookingManager.ConfirmPayment(invoiceId);
    }

    static void ShowUserTickets()
    {
        Console.Write("\nEnter User ID: ");
        string userId = Console.ReadLine() ?? ""; //validate later

        List<Invoice> userPaidInvoices = new List<Invoice>();
        userPaidInvoices = bookingManager.UserPaidInvoice(userId);

        foreach (Invoice invoice in userPaidInvoices)
        {
            Console.WriteLine($"Invoice ID: {invoice.InvoiceId}"); //format output later
        }
    }

    static void WaitForInput()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}