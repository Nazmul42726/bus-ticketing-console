using bus_ticketing_console.Interfaces;
using bus_ticketing_console.Models;
using bus_ticketing_console.Services;
using bus_ticketing_console.Helpers;

namespace bus_ticketing_console;

class Program
{
    static SeatLayoutHelper seatLayoutHelper = new SeatLayoutHelper();
    static IUserManager     userManager      = new UserService();
    static IBusManager      busManager       = new BusService();
    static IScheduleManager scheduleManager  = new ScheduleService();
    static IBookingManager  bookingManager   = new BookingService();

    static void Main()
    {
        while (true)
        {
            ConsoleHelper.DisplayMainMenu();

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
        ConsoleHelper.DisplayTitle("Creating New User");
        
        string name;
        while (true)
        {
            ConsoleHelper.Prompt("Enter User Name");
            name = Console.ReadLine() ?? "";
            Console.ResetColor();

            if (ValidationHelper.IsValidName(name)) break;
        }

        string mobile;
        while (true)
        {
            ConsoleHelper.Prompt("Enter Mobile Number");
            mobile = Console.ReadLine() ?? "";
            Console.ResetColor();

            if (ValidationHelper.IsValidMobileNumber(mobile)) break;
        }

        string email;
        while (true)
        {
            ConsoleHelper.Prompt("Enter Email Address");
            email = Console.ReadLine() ?? "";
            Console.ResetColor();

            if (ValidationHelper.IsValidEmail(email)) break;
        }

        User NewUser = new User
        {
            UserName = name,
            MobileNumber = mobile,
            Email = email
        };

        userManager.CreateUser(NewUser);

        ConsoleHelper.SuccessMessage("User Created Successfully");        
        WaitForInput();
    }
    static void ShowAllUser()
    {
        ConsoleHelper.DisplayTitle("User List");
        List<User> AllUser = userManager.ShowUsers();

        if(AllUser.Count == 0) ConsoleHelper.CautionMessage("No User registered in the system yet");
        else{
            string[] header = {"SL No.", "User ID", "Name", "Mobile Number", "Email Address"};

            List<string[]> rows = new List<string[]>();
            for(int i=0; i<AllUser.Count; i++)
            {
                rows.Add(new string[]
                {
                    (i+1).ToString(),
                    AllUser[i].UserId,
                    AllUser[i].UserName,
                    AllUser[i].MobileNumber,
                    AllUser[i].Email
                });
            }
            ConsoleHelper.DisplayTable(header, rows);
        }
        WaitForInput();
    }

    static void CreateNewBus()          //todo: some index validation, final confirmation
    {   
        ConsoleHelper.DisplayTitle("Adding New Bus");

        string[] header = { "SL No.", "Bus Models" };
        ConsoleHelper.DisplayTable(header, SystemRegistry.BusModelsList());
        ConsoleHelper.Prompt("Select Bus Model");

        string modelChoice = Console.ReadLine() ?? "";
        string modelName = modelChoice switch
        {
            "1" => "Scania Multi-Axle",
            "2" => "Hino 1J",
            "3" => "Hyundai Universe",
            "4" => "Volvo B11R",
            "5" => "Ashok Leyland",
            "6" => "Isuzu Turkuaz",
            "7" => "Mercedes-Benz SHD",
            "8" => "MAN Lion's Coach",
            "9" => "Toyota Coaster",
            "10" => "Mitsubishi Fuso",
            _ => "Standard Fleet Bus" 
        };

        header[1] = "Bus Classifications";
        ConsoleHelper.DisplayTable(header, SystemRegistry.BusClassList());
        ConsoleHelper.Prompt("Select Bus Classification");

        string classChoice = Console.ReadLine() ?? "";
        string classification = classChoice switch
        {
            "1" => "Business",
            "2" => "Economy",
            _ => "Economy"
        };

        int totalCapacity = 40; 

        if (classification == "Business")
        {
            header[1] = "Seating Capacity";
            ConsoleHelper.DisplayTable(header, SystemRegistry.CapacityList(true));
            ConsoleHelper.Prompt("Select Seating Capacity");
            string capacityChoice = Console.ReadLine() ?? "";
            
            totalCapacity = capacityChoice switch
            {
                "1" => 28,
                "2" => 30,
                "3" => 32,
                _ => 30 
            };
        }
        else
        {
            header[1] = "Seating Capacity";
            ConsoleHelper.DisplayTable(header, SystemRegistry.CapacityList(false));
            ConsoleHelper.Prompt("Select Seating Capacity");
            string capacityChoice = Console.ReadLine() ?? "";
            
            totalCapacity = capacityChoice switch
            {
                "1" => 36,
                "2" => 40,
                "3" => 45,
                _ => 40 
            };
        }

        header[1] = "Air-Conditioned (AC) Status";
        ConsoleHelper.DisplayTable(header, SystemRegistry.AcOptionsList());
        ConsoleHelper.Prompt("Selected Status");
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
        ConsoleHelper.SuccessMessage("Bus Registered Successfully");
        WaitForInput();
    }

    static void ShowAllBus()
    {
        ConsoleHelper.DisplayTitle("Bus Fleet List");
        List<Bus> AllBuses = busManager.ShowBuses();

        if (AllBuses.Count == 0)
        {
            ConsoleHelper.CautionMessage("No buses registered in the system yet");
        }
        else
        {
            string[] header = { "SL No.", "Bus ID", "Model Name", "Classification", "Type", "Seats", "Status" };

            List<string[]> rows = new List<string[]>();
            for (int i = 0; i < AllBuses.Count; i++)
            {
                string acStatus = AllBuses[i].IsAirConditioned ? "AC" : "Non-AC";
                string availability = AllBuses[i].IsAvailable ? "Available" : "Not Available";

                rows.Add(new string[]
                {
                    (i + 1).ToString(),
                    AllBuses[i].BusId,
                    AllBuses[i].ModelName,
                    AllBuses[i].Classification,
                    acStatus,
                    AllBuses[i].TotalCapacity.ToString(),
                    availability
                });
            }
            ConsoleHelper.DisplayTable(header, rows);
        }
        WaitForInput();
    }

    static void CreateNewSchedule() //todo: final confirmation, some validation, book bus, (now a bus can be booked multiple times)
    {
        ConsoleHelper.DisplayTitle("Creating New Schedule");
        
        List<Bus> availableBuses = busManager.ShowAvailableBuses();
        if (availableBuses.Count == 0)
        {
            ConsoleHelper.CautionMessage("No buses available");
            WaitForInput();
            return;
        }

        string[] busHeader = { "SL No.", "Model Name", "Classification", "Type", "Seats" };
        List<string[]> busRows = new List<string[]>();
        for (int i = 0; i < availableBuses.Count; i++)
        {
            busRows.Add(new string[]
            {
                (i + 1).ToString(),
                availableBuses[i].ModelName,
                availableBuses[i].Classification,
                availableBuses[i].IsAirConditioned ? "AC" : "Non-AC",
                availableBuses[i].TotalCapacity.ToString()
            });
        }
        ConsoleHelper.DisplayTable(busHeader, busRows);
        
        int busIndex;
        while (true)
        {
            ConsoleHelper.Prompt($"Select Bus (1-{availableBuses.Count})");
            if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 1 && idx <= availableBuses.Count)
            {
                busIndex = idx - 1;
                break;
            }
            ConsoleHelper.ErrorMessage("Invalid Selection");
        }
        Bus selectedBus = availableBuses[busIndex];

        string[] cityHeader = { "SL No.", "Departure Cities" };
        ConsoleHelper.DisplayTable(cityHeader, SystemRegistry.CitiesList());
        
        int departureCityIdx;
        while (true)
        {
            ConsoleHelper.Prompt("Select Departure City");
            if (int.TryParse(Console.ReadLine(), out int depIdx) && depIdx >= 1 && depIdx <= SystemRegistry.Cities.Length)
            {
                departureCityIdx = depIdx - 1;
                break;
            }
            ConsoleHelper.ErrorMessage("Invalid city selection");
        }

        cityHeader[1] = "Arrival Cities";
        ConsoleHelper.DisplayTable(cityHeader, SystemRegistry.CitiesList());
        
        int arrivalCityIdx;
        while (true)
        {
            ConsoleHelper.Prompt("Select Arrival City");
            if (int.TryParse(Console.ReadLine(), out int arvIdx) && arvIdx >= 1 && arvIdx <= SystemRegistry.Cities.Length)
            {
                if(arvIdx - 1 == departureCityIdx)
                {
                    ConsoleHelper.ErrorMessage("Selected same Departure City and Arrival City");
                    continue;
                }
                arrivalCityIdx = arvIdx - 1;
                break;
            }
            ConsoleHelper.ErrorMessage("Invalid city selection");
        }

        int day, month, hour, minute;
        while (true)
        {
            ConsoleHelper.Prompt("Enter Month (1-12)");
            if (int.TryParse(Console.ReadLine(), out month) && month >= 1 && month <= 12) break;
            ConsoleHelper.ErrorMessage("Invalid month!");
        }

        while (true)
        {
            ConsoleHelper.Prompt("Enter Day (1-31)");
            if (int.TryParse(Console.ReadLine(), out day) && day >= 1 && day <= 31) break;
            ConsoleHelper.ErrorMessage("Invalid day");
        }

        while (true)
        {
            ConsoleHelper.Prompt("Enter Hour (0-23)");
            if (int.TryParse(Console.ReadLine(), out hour) && hour >= 0 && hour <= 23) break;
            ConsoleHelper.ErrorMessage("Invalid hour");
        }

        while (true)
        {
            ConsoleHelper.Prompt("Enter Minute (0-59)");
            if (int.TryParse(Console.ReadLine(), out minute) && minute >= 0 && minute <= 59) break;
            ConsoleHelper.ErrorMessage("Invalid minute");
        }

        string formattedDateTime = $"2026-{month:D2}-{day:D2} {hour:D2}:{minute:D2}";

        double confirmedPrice = 0;
        while (true)
        {
            ConsoleHelper.Prompt("Enter Ticket Price (BDT)");
            string firstInput = Console.ReadLine() ?? "";
            
            if (!double.TryParse(firstInput, out double firstPrice) || firstPrice <= 0)
            {
                ConsoleHelper.ErrorMessage("Price must be a valid number greater than 0.");
                continue;
            }

            ConsoleHelper.Prompt("Re-enter Ticket Price");
            string secondInput = Console.ReadLine() ?? "";
            
            if (double.TryParse(secondInput, out double secondPrice) && firstPrice == secondPrice)
            {
                confirmedPrice = firstPrice;
                break;
            }
            ConsoleHelper.ErrorMessage("Prices do not match or input was invalid! Try again");
        }

        Schedule newSchedule = new Schedule
        {
            DepartureCity     = SystemRegistry.Cities[departureCityIdx],
            ArrivalCity       = SystemRegistry.Cities[arrivalCityIdx],
            DepartureDateTime = formattedDateTime,
            TicketPrice       = confirmedPrice,
            AssignedBus       = selectedBus
        };

        scheduleManager.CreateSchedule(newSchedule);
        ConsoleHelper.SuccessMessage($"Schedule Created Successfully");
        WaitForInput();
    }

    static void ShowAllSchedule()
    {
        ConsoleHelper.DisplayTitle("Active Bus Schedules");
        List<Schedule> AllSchedules = scheduleManager.ShowSchedule();

        if (AllSchedules.Count == 0)
        {
            ConsoleHelper.CautionMessage("No schedules registered in the system yet");
        }
        else
        {
            string[] header = { "SL No.", "Schedule ID", "Route (From - To)", "Departure Date & Time", "Fare (BDT)", "Available Seats" };

            List<string[]> rows = new List<string[]>();
            for (int i = 0; i < AllSchedules.Count; i++)
            {
                Schedule schedule = AllSchedules[i];
                int availableSeatsCount = schedule.AssignedBus.TotalCapacity - schedule.ReservedSeats.Count;
                string route = $"{schedule.DepartureCity} ➔ {schedule.ArrivalCity}";

                rows.Add(new string[]
                {
                    (i + 1).ToString(),
                    schedule.ScheduleId,
                    route,
                    schedule.DepartureDateTime,
                    schedule.TicketPrice.ToString("F2"),
                    $"{availableSeatsCount} / {schedule.AssignedBus.TotalCapacity}"
                });
            }
            ConsoleHelper.DisplayTable(header, rows);
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