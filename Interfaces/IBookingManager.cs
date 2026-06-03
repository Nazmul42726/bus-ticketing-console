using bus_ticketing_console.Models;

namespace bus_ticketing_console.Interfaces;

public interface IBookingManager
{
    void BookATicket(Invoice invoice);
    List<Invoice> UserInvoice(string userId);
    // Invoice? InvoiceDetails(string invoiceId);
    void ConfirmPayment(string invoiceId);
    List<Invoice> UserPaidInvoice(string userId);
}