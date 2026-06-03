using bus_ticketing_console.Interfaces;
using bus_ticketing_console.Models;

namespace bus_ticketing_console.Services;

public class BookingService : IBookingManager
{
    private readonly List<Invoice> _invoiceList = new List<Invoice>();
    private int _totalInvoice = 0;
    public void BookATicket(Invoice invoice)
    {
        invoice.InvoiceId = $"INV-{_totalInvoice:X3}";
        _totalInvoice++;
        _invoiceList.Add(invoice);
    }
    public List<Invoice> UserInvoice(string userId)
    {
        List<Invoice> userInvoices = new List<Invoice>();
        foreach(Invoice inv in _invoiceList)
        {
            if(inv.UserId == userId)
            {
                userInvoices.Add(inv);
            }
        }
        return userInvoices;
    } 
    public void ConfirmPayment(string invoiceId)
    {
        Invoice? invoice = _invoiceList.FirstOrDefault(inv => inv.InvoiceId == invoiceId);
        if(invoice == null) return;
        invoice.PaymentStatus = true;
    }
    public List<Invoice> UserPaidInvoice(string userId)
    {
        List<Invoice> userPaidInvoices = new List<Invoice>();
        foreach(Invoice inv in _invoiceList)
        {
            if(inv.UserId == userId && inv.PaymentStatus)
            {
                userPaidInvoices.Add(inv);
            }
        }
        return userPaidInvoices;
    }
    public bool IsValidInvoiceId(string invoiceId)
    {
        foreach(Invoice invoice in _invoiceList)
        {
            if(invoice.InvoiceId == invoiceId) return true;
        }
        return false;
    }
}