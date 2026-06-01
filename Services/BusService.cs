using bus_ticketing_console.Interfaces;
using bus_ticketing_console.Models;

namespace bus_ticketing_console.Services;

public class BusService : IBusManager
{
    private readonly List<Bus> _busList = new List<Bus>();
    private int _totalBus = 0;
    public void CreateBus(Bus bus)
    {
        bus.BusId = $"BUS-{_totalBus:X3}";
        _totalBus++;
        _busList.Add(bus);
    }

    public List<Bus> ShowBuses()
    {
        return _busList;
    }
}