namespace bus_ticketing_console.Models;

public class Invoice
{
    public string InvoiceId = string.Empty;
    
    public required string UserId {get; set;}
    public required string ScheduleId{get; set;}
    public required string SelectedSeat{get; set;}
    public bool PaymentStatus {get; set;} = false;
}