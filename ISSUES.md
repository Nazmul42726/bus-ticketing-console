# Code Review: SOLID and OOP Principle Violations

This document outlines the violations of SOLID principles, core OOP design concepts, and industry-standard C# clean code practices found in this bus ticketing console application.

---

## SOLID Principles

### Single Responsibility Principle (SRP)
- [ ] **File: [ValidationHelper.cs](file:///home/nazmulhasan/Base/submitted-snap/Helpers/ValidationHelper.cs) (Lines 8-97)**
  - **Violation**: The validation methods (`IsValidName`, `IsValidMobileNumber`, and `IsValidEmail`) perform console UI operations (coloring, changing console states, and writing error messages) in addition to executing validation logic.
  - **Why it violates SRP**: The helper class has two distinct responsibilities: enforcing business rules/input validation and rendering visual outputs. If the UI design changes (e.g., changing colors or message formats), this core business class must be modified.
  - **Industry-Standard Fix**: Remove all Console UI code from the helper class. Return a structured validation result (like a custom `ValidationResult` type) and let the calling presentation layer (`Program.cs`) print the errors.
  - **Why it matters**: Mixing UI and business logic makes validations non-reusable (e.g., they cannot be used in a web API, mobile app, or desktop UI) and makes writing unit tests extremely difficult since assertions would require capturing and parsing the standard console output stream.
  - [ ] 1. Create a `ValidationResult` record: `public record ValidationResult(bool IsValid, string? ErrorMessage);`.
  - [ ] 2. Update `ValidationHelper.IsValidName` to return `ValidationResult` instead of `bool`.
  - [ ] 3. Remove all references to `Console.ForegroundColor`, `Console.WriteLine`, and `Console.ResetColor` from `IsValidName` and return `new ValidationResult(false, "Name cannot be empty.")` (or appropriate error message) on failure, and `new ValidationResult(true, null)` on success.
  - [ ] 4. Apply the same pattern to `IsValidMobileNumber` and `IsValidEmail`.
  - [ ] 5. In `Program.cs`, capture the returned `ValidationResult` and call `ConsoleHelper.ErrorMessage` with the error message if the result is invalid.

- [ ] **File: [Program.cs](file:///home/nazmulhasan/Base/submitted-snap/Program.cs) (Lines 8-660)**
  - **Violation**: The `Program` class acts as a monolithic coordinator, handling application state, reading terminal input, writing terminal output, constructing services, validating inputs, and routing flows.
  - **Why it violates SRP**: It acts as a God Class. It has multiple reasons to change, such as changes in UI layouts, menu flows, input validation rules, and business coordinator flow logic.
  - **Industry-Standard Fix**: Separate concerns by decomposing `Program.cs` into distinct layers: a UI Console Presentation Layer (Views), a Controller/Coordinator (Application Services), and a Bootstrapper (Composition Root).
  - **Why it matters**: God classes grow rapidly, making the codebase hard to maintain, prone to merge conflicts, and impossible to unit-test because UI, state, and business operations are coupled.
  - [ ] 1. Create a `ConsoleView` class and move all user-input reading and console writing methods (e.g., `CreateNewUser`, `ShowAllUser`, `CreateNewBus`, etc.) into it.
  - [ ] 2. Create a `BookingController` or `ConsoleApplication` class to manage the main application menu loop and coordinate calls between views and services.
  - [ ] 3. Simplify the `Program.Main` method to only initialize the application dependencies, bootstrap the controller, and start the application loop.

---

### Open/Closed Principle (OCP)
- [ ] **File: [Helpers/ValidationHelper.cs](file:///home/nazmulhasan/Base/submitted-snap/Helpers/ValidationHelper.cs) (Lines 99-118)**
  - **Violation**: The `IsValidSeat` method uses a hardcoded `switch` statement on specific seat capacities: `switch (busCapacity) { case 28: ... case 30: ... }`.
  - **Why it violates OCP**: The validation logic is closed to extension and open to modification. If a new class of bus with a different seat capacity (e.g., 50 seats) is introduced, the developer must modify the switch statement and add new static lists in `SystemRegistry.cs`.
  - **Industry-Standard Fix**: Seat validity should be checked against the specific `Bus` layout configuration dynamically, rather than hardcoding capacity-mapping switch statements in a static utility.
  - **Why it matters**: In production, new bus models and seat configurations are common. Modifying core validation files for every configuration change risks introducing bugs in existing tested code paths.
  - [ ] 1. Add a property `ValidSeats` of type `IReadOnlyList<string>` to the `Bus` model.
  - [ ] 2. Populate `ValidSeats` dynamically during bus construction or via a factory based on its capacity.
  - [ ] 3. Refactor `ValidationHelper.IsValidSeat` to accept the collection of valid seats: `public static bool IsValidSeat(string seat, IEnumerable<string> validSeats)`.
  - [ ] 4. Replace the switch block inside `IsValidSeat` with: `return validSeats.Contains(seat);`.
  - [ ] 5. Update the caller in `Program.cs` line 519 to pass `selectedSchedule.AssignedBus.ValidSeats` to the validation method.

- [ ] **File: [Helpers/SeatLayoutHelper.cs](file:///home/nazmulhasan/Base/submitted-snap/Helpers/SeatLayoutHelper.cs) (Lines 5-28 and 30-412)**
  - **Violation**: The `PrintSeatLayout` method uses a `switch` statement on `totalSeats` and calls concrete layout methods (`SeatLayout28`, `SeatLayout30`, etc.) containing console graphics for each.
  - **Why it violates OCP**: Adding a new seating capacity requires modifying the class by adding a new switch case and writing a new layout rendering method.
  - **Industry-Standard Fix**: Introduce an abstraction (e.g., `ISeatLayoutRenderer`) and implement concrete rendering classes for each layout style. Alternatively, write a single layout generator that dynamically renders the grid using row count, column count, and aisle placement metadata.
  - **Why it matters**: Polymorphic layout renderers isolate layouts from each other. You can introduce a new seating layout without risking breaking existing tested layout renderings.
  - [ ] 1. Create an interface `ISeatLayoutRenderer` with a single method: `void Print(IReadOnlyCollection<string> bookedSeats, IReadOnlyCollection<string> reservedSeats);`.
  - [ ] 2. Create concrete classes for each layout type: e.g., `SeatLayoutRenderer28`, `SeatLayoutRenderer30`, etc., implementing `ISeatLayoutRenderer`.
  - [ ] 3. Move the hardcoded printing code from `SeatLayoutHelper` into these corresponding classes.
  - [ ] 4. Implement a factory class `SeatLayoutRendererFactory` that returns the correct `ISeatLayoutRenderer` instance based on seat count or classification.
  - [ ] 5. In `Program.cs`, get the appropriate renderer from the factory and call its `Print` method.

- [ ] **File: [Program.cs](file:///home/nazmulhasan/Base/submitted-snap/Program.cs) (Lines 165-178, 201-207, 216-222)**
  - **Violation**: Hardcoded switch statements mapping option inputs ("1", "2") to bus models, classifications, and capacities in the `CreateNewBus` method.
  - **Why it violates OCP**: If the company acquires a new bus model or introduces a new capacity, developers must modify these switches inside `Program.cs`.
  - **Industry-Standard Fix**: Store configuration mappings in a config file, registry dictionary, or metadata provider, then render and select options dynamically.
  - **Why it matters**: Hardcoding configuration choices in UI interaction methods couples UI navigation to business properties, leading to code bloat and high maintenance overhead.
  - [ ] 1. Define a `BusConfiguration` structure or record to hold model name, classification, capacity, and AC options.
  - [ ] 2. Expose the list of available Configurations in `SystemRegistry` or a separate repository.
  - [ ] 3. In `Program.cs`, replace the hardcoded switches by iterating through the configuration list, printing them with index numbers, and resolving choices by index.

---

### Liskov Substitution Principle (LSP)
- [ ] **Codebase Analysis**
  - **Analysis**: There are no inheritance relationships between classes (no class inherits from another class) in this codebase, only interface implementations. The implementations of `IUserManager`, `IBusManager`, `IScheduleManager`, and `IBookingManager` do not throw unexpected exceptions or alter the contracts of their interfaces in a way that violates LSP. However, the lack of inheritance and polymorphic behavior where appropriate (e.g., subclassing layouts) is a core OOP design flaw addressed in the OOP principles section below.

---

### Interface Segregation Principle (ISP)
- [ ] **File: [Interfaces/IBookingManager.cs](file:///home/nazmulhasan/Base/submitted-snap/Interfaces/IBookingManager.cs) (Lines 5-13)**
  - **Violation**: The `IBookingManager` interface combines ticket booking (`BookATicket`), payment processing (`ConfirmPayment`), and invoice querying (`UserInvoice`, `UserPaidInvoice`, `IsValidInvoiceId`).
  - **Why it violates ISP**: Clients depending on `IBookingManager` (e.g., a billing module or search/reporting component) are forced to depend on methods they do not need (such as ticketing or payment processing).
  - **Industry-Standard Fix**: Segregate the interface into smaller, single-purpose contracts like `ITicketBookingService`, `IPaymentProcessor`, and `IInvoiceQueryService`.
  - **Why it matters**: Large, monolithic interfaces make testing difficult (mocks require stubbing unused methods) and increase coupling, causing changes in one part of the system (e.g. payment flow) to propagate to unrelated clients (e.g. viewing history).
  - [ ] 1. Define `ITicketBookingService` with the `BookATicket` method.
  - [ ] 2. Define `IPaymentProcessor` with the `ConfirmPayment` method.
  - [ ] 3. Define `IInvoiceQueryService` with `UserInvoice`, `UserPaidInvoice`, and `IsValidInvoiceId` methods.
  - [ ] 4. Have `BookingService` implement all three interfaces.
  - [ ] 5. Inject only the specific interfaces needed into the respective client classes.

---

### Dependency Inversion Principle (DIP)
- [ ] **File: [Program.cs](file:///home/nazmulhasan/Base/submitted-snap/Program.cs) (Lines 10-14)**
  - **Violation**: The `Program` class directly instantiates concrete services using the `new` keyword (`new UserService()`, `new BusService()`, `new ScheduleService()`, `new BookingService()`, `new SeatLayoutHelper()`).
  - **Why it violates DIP**: The program depends on concrete low-level implementations rather than resolving dependencies via abstractions. Although declared as interfaces, direct instantiation tightly couples `Program.cs` to specific concrete classes.
  - **Industry-Standard Fix**: Implement a Dependency Injection container (using standard `Microsoft.Extensions.DependencyInjection`) to register services and inject them via constructor injection or retrieve them from a service provider.
  - **Why it matters**: Direct instantiations make it impossible to swap implementations (e.g., swapping `UserService` with a database-backed service, or mocking them for testing) without rewriting code inside `Program.cs`.
  - [ ] 1. Install the NuGet package `Microsoft.Extensions.DependencyInjection`.
  - [ ] 2. In `Program.cs`, create a method `ConfigureServices(IServiceCollection services)` to register interfaces to their concrete implementations (e.g., `services.AddSingleton<IUserManager, UserService>();`).
  - [ ] 3. Build the `ServiceProvider` inside the entry method.
  - [ ] 4. Resolve the dependencies from the provider or inject them into the controllers, removing direct `new` instantiations of services.

---

## Core OOP Principles

### Encapsulation
- [ ] **Files: [BusService.cs](file:///home/nazmulhasan/Base/submitted-snap/Services/BusService.cs) (Line 19), [ScheduleService.cs](file:///home/nazmulhasan/Base/submitted-snap/Services/ScheduleService.cs) (Line 23), [UserService.cs](file:///home/nazmulhasan/Base/submitted-snap/Services/UserService.cs) (Line 19)**
  - **Violation**: The methods `ShowBuses()`, `ShowSchedule()`, and `ShowUsers()` return internal mutable collections (`_busList`, `_scheduleList`, `_userList`) directly to callers.
  - **Why it violates Encapsulation**: Returning a direct reference to a private `List<T>` allows external classes to mutate the internal state of the service (e.g., `busManager.ShowBuses().Clear()` or adding invalid items directly). This bypasses the encapsulation safety of the manager classes.
  - **Industry-Standard Fix**: Expose internal collections as read-only representations, such as `IReadOnlyList<T>` or `IEnumerable<T>`, and return them wrapped in a read-only collection wrapper using `.AsReadOnly()`.
  - **Why it matters**: Protecting collections prevents external code from accidentally or maliciously modifying data structures behind the service's back, avoiding bugs related to inconsistent states.
  - [ ] 1. In `IBusManager` and `BusService`, change the return type of `ShowBuses()` to `IReadOnlyList<Bus>`.
  - [ ] 2. In `BusService.ShowBuses()`, return `_busList.AsReadOnly()`.
  - [ ] 3. Repeat the same change for `ShowSchedule()` in `IScheduleManager` / `ScheduleService` to return `IReadOnlyList<Schedule>`.
  - [ ] 4. Repeat the same change for `ShowUsers()` in `IUserManager` / `UserService` to return `IReadOnlyList<User>`.

- [ ] **File: [Models/Invoice.cs](file:///home/nazmulhasan/Base/submitted-snap/Models/Invoice.cs) (Line 5)**
  - **Violation**: `InvoiceId` is declared as a public field: `public string InvoiceId = string.Empty;`.
  - **Why it violates Encapsulation**: C# classes should not expose public fields because they provide no control over access or validation. Any external code can assign arbitrary values to the field at any point.
  - **Industry-Standard Fix**: Expose properties instead of public fields, using properties with `get` and `init`/`private set` accessors.
  - **Why it matters**: Fields do not support data binding, cannot enforce validations on assignment, cannot be marked as virtual, and cannot be intercepted (e.g., by ORMs or debuggers). Exposing properties ensures the class retains control over its data.
  - [ ] 1. Refactor `Invoice.cs` line 5 to change `InvoiceId` from a field to an auto-property: `public string InvoiceId { get; set; } = string.Empty;`.

- [ ] **File: [Models/Schedule.cs](file:///home/nazmulhasan/Base/submitted-snap/Models/Schedule.cs) (Lines 15-16)**
  - **Violation**: `BookedSeats` and `ReservedSeats` lists are exposed as mutable `List<string>` with public setters: `public List<string> BookedSeats {get; set;} = new List<string>();`.
  - **Why it violates Encapsulation**: A caller can completely replace the list (`schedule.BookedSeats = null;`) or add/remove seats directly from outside the class (as seen in `Program.cs` line 541: `selectedSchedule.BookedSeats.Add(selectedSeat);`). The `Schedule` class loses control over its invariants.
  - **Industry-Standard Fix**: Change the properties to read-only collections (`IReadOnlyList<string>`) and expose clean behavior-oriented methods on `Schedule` (like `BookSeat(string seat)`) to modify the seats.
  - **Why it matters**: Keeping collections read-only ensures that state modifications follow domain business rules (e.g., seat capacity limits, seat formats, double-booking prevention) that are checked and run internally.
  - [ ] 1. Change `BookedSeats` and `ReservedSeats` in `Schedule.cs` to read-only properties backed by private fields: `private readonly List<string> _bookedSeats = new(); public IReadOnlyList<string> BookedSeats => _bookedSeats.AsReadOnly();`.
  - [ ] 2. Implement a method `public bool BookSeat(string seat)` in `Schedule` to validate and add the seat.
  - [ ] 3. Update the booking code in `Program.cs` (line 541) to call `selectedSchedule.BookSeat(selectedSeat)`.

- [ ] **Files: [Bus.cs](file:///home/nazmulhasan/Base/submitted-snap/Models/Bus.cs), [User.cs](file:///home/nazmulhasan/Base/submitted-snap/Models/User.cs), [Schedule.cs](file:///home/nazmulhasan/Base/submitted-snap/Models/Schedule.cs), [Invoice.cs](file:///home/nazmulhasan/Base/submitted-snap/Models/Invoice.cs)**
  - **Violation**: The domain models have no behavior, only public getters and setters (Anemic Domain Model code smell).
  - **Why it violates Encapsulation**: Data and behavior are separated. The logic to create buses, format code numbers, and manage identifiers is placed in the service classes and UI layer. OOP mandates that data and the operations that act upon that data should be bound together.
  - **Industry-Standard Fix**: Rich Domain Model design. Move state-changing logic and business validations into the models themselves and restrict setters to `init` or `private set` to guarantee integrity.
  - **Why it matters**: Anemic models lead to duplicated business logic across services and controllers. Rich models ensure business constraints (invariants) are checked consistently in one single place.
  - [ ] 1. Change setters for key fields (e.g., `BusId`, `UserId`, `ModelName`, etc.) to `init;` or `private set;`.
  - [ ] 2. Add parameterized constructors to construct valid entities with mandatory fields.
  - [ ] 3. Relocate ID formatting logic (e.g. generator rules) or status toggles to domain methods inside the models.

---

### Abstraction
- [ ] **Files: [Helpers/SeatLayoutHelper.cs](file:///home/nazmulhasan/Base/submitted-snap/Helpers/SeatLayoutHelper.cs), [Program.cs](file:///home/nazmulhasan/Base/submitted-snap/Program.cs)**
  - **Violation**: Missing interface abstraction for printing seat layouts and performing Console operations.
  - **Why it violates Abstraction**: Both the main control flow and seat printing depend on concrete implementations, violating the abstraction principle of OOP. It creates a direct dependency on the terminal Console window.
  - **Industry-Standard Fix**: Introduce interfaces like `ISeatLayoutPrinter` and `IConsoleProvider` to hide physical output implementation details.
  - **Why it matters**: Providing abstractions allows swapping out Console output with a Web View or GUI without altering the business logic. It also supports unit testing via mock/fake console implementations.
  - [ ] 1. Extract interface `ISeatLayoutPrinter` from `SeatLayoutHelper` containing the method `PrintSeatLayout`.
  - [ ] 2. Extract interface `IConsoleProvider` with basic methods `WriteLine`, `ReadLine`, and `Clear`.
  - [ ] 3. Program against these interfaces instead of using concrete classes or standard static `Console` statements.

---

### Polymorphism
- [ ] **Files: [Helpers/SeatLayoutHelper.cs](file:///home/nazmulhasan/Base/submitted-snap/Helpers/SeatLayoutHelper.cs) (Lines 8-28), [Helpers/ValidationHelper.cs](file:///home/nazmulhasan/Base/submitted-snap/Helpers/ValidationHelper.cs) (Lines 99-118)**
  - **Violation**: Branching on primitive properties (like seat counts/capacity numbers) to print the seat layout and validate seat numbers.
  - **Why it violates Polymorphism**: Procedural branching is used where polymorphic execution is appropriate. In OOP, subclasses or implementations should define custom behavior, and client code should interact with them through their base contracts.
  - **Industry-Standard Fix**: Model different bus configurations or layouts as objects implementing a common seat behavior interface and invoke layout and validation methods polymorphically.
  - **Why it matters**: Branching on types or magic numbers means that adding new configurations requires updates to multiple helpers. Polymorphic objects isolate these additions, keeping changes local to new classes.
  - [ ] 1. Define a `SeatLayout` abstraction (interface or abstract class) containing `void Render(List<string> booked, List<string> reserved)` and `bool IsValidSeat(string seat)`.
  - [ ] 2. Create concrete classes `LuxurySeatLayout`, `EconomySeatLayout`, etc., that implement the rendering and list validation.
  - [ ] 3. Associate the correct `SeatLayout` implementation with the `Bus` or `Schedule` object.
  - [ ] 4. Call `schedule.Layout.Render(...)` and `schedule.Layout.IsValidSeat(...)` polymorphically in `Program.cs`.

---

### Inheritance
- [ ] **Files: [Models/Bus.cs](file:///home/nazmulhasan/Base/submitted-snap/Models/Bus.cs), [Models/User.cs](file:///home/nazmulhasan/Base/submitted-snap/Models/User.cs), [Models/Schedule.cs](file:///home/nazmulhasan/Base/submitted-snap/Models/Schedule.cs), [Models/Invoice.cs](file:///home/nazmulhasan/Base/submitted-snap/Models/Invoice.cs)**
  - **Violation**: The entities do not share any common entity foundation or base properties, leading to code duplication in identity tracking and service list queries.
  - **Why it violates OOP Inheritance**: Standard infrastructure concerns (identity, auditing, registry tracking) are not generalized using base classes.
  - **Industry-Standard Fix**: Introduce an abstract `EntityBase<TId>` base class to standardize entity identities.
  - **Why it matters**: Standardizing entity attributes allows developers to write generic repositories, search logs, and auditable pipelines without duplicating infrastructure code across every class.
  - [ ] 1. Create a base class `EntityBase<T>` with a property `public T Id { get; init; }`.
  - [ ] 2. Refactor `Bus`, `User`, `Schedule`, and `Invoice` to inherit from `EntityBase<string>`.
  - [ ] 3. Rename specific ID properties like `BusId`, `UserId` to `Id` throughout the application.

---

## Other Industry-Standard C# / OOP Practices

### Magic Numbers and Strings
- [ ] **Files: [Program.cs](file:///home/nazmulhasan/Base/submitted-snap/Program.cs) (Lines 165-178, 184-190, 201-222), [Helpers/ValidationHelper.cs](file:///home/nazmulhasan/Base/submitted-snap/Helpers/ValidationHelper.cs) (Lines 99-114)**
  - **Violation**: Magic numbers (28, 30, 32, 36, 40, 45) and magic strings (`"Business"`, `"Economy"`, `"AC"`, `"NonAC"`) are hardcoded across multiple files for comparison and flow control.
  - **Why it is poor practice**: Magic values have no context, are prone to typographical errors, and are difficult to update. A typo like `"economy"` instead of `"Economy"` will cause silent runtime logic failures.
  - **Industry-Standard Fix**: Define enums (`BusClassification`, `AcStatus`) and constants for capacities and layout types.
  - **Why it matters**: Enums force compile-time safety and self-document the code, making options discoverable via IntelliSense and preventing typos.
  - [ ] 1. Create a `BusClassification` enum: `public enum BusClassification { Business, Economy }`.
  - [ ] 2. Replace the `"Business"` and `"Economy"` string checks with the `BusClassification` enum.
  - [ ] 3. Replace AC boolean/string logic with an `AcStatus` enum.
  - [ ] 4. Define capacity integers as constants or read-only settings arrays.

---

### Inappropriate Data Types
- [ ] **File: [Models/Schedule.cs](file:///home/nazmulhasan/Base/submitted-snap/Models/Schedule.cs) (Lines 11-12)**
  - **Violation**: `DepartureDateTime` is declared as a `string` (e.g., `2026-05-10 14:00`), and `TicketPrice` is declared as a `double`.
  - **Why it is poor practice**: `string` is inappropriate for date/time because it prevents sorting, timezone comparisons, and date mathematics. `double` is a binary floating-point type and can introduce rounding errors when performing financial operations.
  - **Industry-Standard Fix**: Use `DateTimeOffset` or `DateTime` for timestamps, and use `decimal` for monetary values.
  - **Why it matters**: Using `decimal` ensures absolute mathematical precision for currency. Date types prevent invalid entries (like "Feb 30") and simplify operations (like subtracting hours to check cancellation policies).
  - [ ] 1. In `Schedule.cs`, change `DepartureDateTime` to `DateTimeOffset`.
  - [ ] 2. Change the type of `TicketPrice` in `Schedule.cs` and `Program.cs` to `decimal`.
  - [ ] 3. Update the DateTime compiler loop in `Program.cs` (lines 351-380) to instantiate a proper `DateTimeOffset` object.
  - [ ] 4. Replace `double.TryParse` with `decimal.TryParse` for ticket price input.

---

### Tight Coupling & Poor Separation of Concerns
- [ ] **File: [Models/SystemRegistry.cs](file:///home/nazmulhasan/Base/submitted-snap/Models/SystemRegistry.cs)**
  - **Violation**: The class uses static arrays and lists to store static configuration data, and service classes reference `SystemRegistry` statically.
  - **Why it is poor practice**: Static registries are tightly coupled to the application and cannot be mocked, loaded dynamically from databases, or configured per-environment.
  - **Industry-Standard Fix**: Convert static configurations into repository dependencies or configuration settings injected into the services that require them.
  - **Why it matters**: Decoupling config data lets you run tests under different settings (e.g. testing with custom test routes) without modifying codebase constants.
  - [ ] 1. Create an interface `IRegistryService` defining retrieval methods for cities, capacities, and models.
  - [ ] 2. Refactor `SystemRegistry` to implement `IRegistryService` using instance fields.
  - [ ] 3. Register it in the dependency container and inject it into the components that need configuration information.

---

### Improper Exception & Error Handling
- [ ] **File: [Services/BookingService.cs](file:///home/nazmulhasan/Base/submitted-snap/Services/BookingService.cs) (Line 31), [Program.cs](file:///home/nazmulhasan/Base/submitted-snap/Program.cs) (Lines 459, 507, etc.)**
  - **Violation**: The codebase lacks exception handling constructs. Inputs are checked procedurally, and services fail silently (e.g. returning empty or null on missing IDs or bad inputs) rather than throwing structured exceptions.
  - **Why it is poor practice**: Silent failures mask errors, allowing execution to continue with corrupted or null data, eventually leading to unpredictable crashes later in the execution flow.
  - **Industry-Standard Fix**: Throw specific domain exceptions (e.g. `NotFoundException`, `ValidationException`) when invariants are violated, and implement a global exception handling block to intercept and log these errors.
  - **Why it matters**: Structured exception handling makes applications robust. It provides clear diagnostics on what went wrong and prevents crashes by gracefully returning to the main menu.
  - [ ] 1. Define custom exceptions: `EntityNotFoundException` and `BusinessRuleViolationException`.
  - [ ] 2. In `BookingService.ConfirmPayment`, replace `if(invoice == null) return;` with a throw statement: `throw new EntityNotFoundException($"Invoice {invoiceId} was not found.");`.
  - [ ] 3. In `Program.cs`, wrap the main interaction cases in a general `try-catch` block that catches these domain exceptions and prints their messages.

---

### Naming Conventions & Clean Code
- [ ] **Files: [Services/BusService.cs](file:///home/nazmulhasan/Base/submitted-snap/Services/BusService.cs) (Line 24), [Program.cs](file:///home/nazmulhasan/Base/submitted-snap/Program.cs) (Lines 120, 231, etc.)**
  - **Violation**: Local variables are named using PascalCase (e.g. `AvailableBuses`, `NewUser`, `NewBus`) rather than camelCase. Commented-out dead code is left in interfaces.
  - **Why it is poor practice**: Deviating from C# coding conventions (`camelCase` for local variables, `PascalCase` for properties/methods) creates inconsistency, making it harder for team members to read code. Commented-out code causes visual noise.
  - **Industry-Standard Fix**: Follow Microsoft C# coding conventions. Use camelCase for local variables. Remove commented-out code.
  - **Why it matters**: Consistent style reduces cognitive load. Clean codebases do not store obsolete comments since source control (Git) retains history.
  - [ ] 1. Rename local variables like `AvailableBuses`, `NewUser`, `NewBus` to `availableBuses`, `newUser`, `newBus` across all methods.
  - [ ] 2. Remove the commented-out code `// Invoice? InvoiceDetails(string invoiceId);` in `Interfaces/IBookingManager.cs` line 9.
  - [ ] 3. Remove all stale `//todo` comments in `Program.cs`.
