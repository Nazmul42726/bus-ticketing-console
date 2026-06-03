using bus_ticketing_console.Models;

namespace bus_ticketing_console.Interfaces;

public interface IBusManager
{
    void CreateBus(Bus bus);
    List<Bus> ShowBuses();
    List<Bus> ShowAvailableBuses();
}