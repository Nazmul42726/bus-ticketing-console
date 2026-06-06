namespace bus_ticketing_console.Models;

public class Invoice
{
    public required string InvoiceId {get; set;}
    public required string UserId {get; set;}
    public required string ScheduleId{get; set;}
    public required string SelectedSeat{get; set;}
    public bool PaymentStatus {get; set;} = false;
}