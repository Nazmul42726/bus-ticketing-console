namespace bus_ticketing_console.Models;

public class SystemRegistry
{
    public static readonly string[] BusModels = new string[]
    {
        "Scania Multi-Axle",
        "Hino 1J",
        "Hyundai Universe",
        "Volvo B11R",
        "Ashok Leyland",
        "Isuzu Turkuaz",
        "Mercedes-Benz SHD",
        "MAN Lion's Coach",
        "Toyota Coaster",
        "Mitsubishi Fuso"
    };

    public static readonly string[] BusClass = new string[]
    {
        "Business Class",
        "Economy Class"
    };

    public static readonly string[] BusinessCapacities = new string[]
    {
        "28 Seats [Ultra Luxury]",
        "30 Seats [Executive]",
        "32 Seats [Standard]"
    };

    public static readonly string[] EconomyCapacities = new string[]
    {
        "36 Seats [Spacious]",
        "40 Seats [Standard Comfort]",
        "45 Seats [High Capacity]"
    };

    public static readonly string[] AcOptions = new string[]
    {
        "Yes [AC]",
        "No [Non-AC]"
    };

    public static readonly IReadOnlyList<string> Seats28 = new string[]
    {
        "1A", "1B", "1C", "2A", "2B", "2C", "3A", "3B", "3C", "4A", "4B", "4C",
        "5A", "5B", "5C", "6A", "6B", "6C", "7A", "7B", "7C", "8A", "8B", "8C",
        "9A", "9E", "9B", "9C"
    };

    public static readonly IReadOnlyList<string> Seats30 = new string[]
    {
        "1A", "1B", "1C", "2A", "2B", "2C", "3A", "3B", "3C", "4A", "4B", "4C",
        "5A", "5B", "5C", "6A", "6B", "6C", "7A", "7B", "7C", "8A", "8B", "8C",
        "9A", "9B", "9C", "10A", "10B", "10C"
    };

    public static readonly IReadOnlyList<string> Seats32 = new string[]
    {
        "1B", "1C", "2A", "2B", "2C", "3A", "3B", "3C", "4A", "4B", "4C",
        "5A", "5B", "5C", "6A", "6B", "6C", "7A", "7B", "7C", "8A", "8B", "8C",
        "9A", "9B", "9C", "10A", "10B", "10C", "11A", "11B", "11C"
    };

    public static readonly IReadOnlyList<string> Seats36 = new string[]
    {
        "1A", "1B", "1C", "1D", "2A", "2B", "2C", "2D", "3A", "3B", "3C", "3D",
        "4A", "4B", "4C", "4D", "5A", "5B", "5C", "5D", "6A", "6B", "6C", "6D",
        "7A", "7B", "7C", "7D", "8A", "8B", "8C", "8D", "9A", "9B", "9C", "9D"
    };

    public static readonly IReadOnlyList<string> Seats40 = new string[]
    {
        "1A", "1B", "1C", "1D", "2A", "2B", "2C", "2D", "3A", "3B", "3C", "3D",
        "4A", "4B", "4C", "4D", "5A", "5B", "5C", "5D", "6A", "6B", "6C", "6D",
        "7A", "7B", "7C", "7D", "8A", "8B", "8C", "8D", "9A", "9B", "9C", "9D",
        "10A", "10B", "10C", "10D"
    };

    public static readonly IReadOnlyList<string> Seats45 = new string[]
    {
        "1A", "1B", "1C", "1D", "2A", "2B", "2C", "2D", "3A", "3B", "3C", "3D",
        "4A", "4B", "4C", "4D", "5A", "5B", "5C", "5D", "6A", "6B", "6C", "6D",
        "7A", "7B", "7C", "7D", "8A", "8B", "8C", "8D", "9A", "9B", "9C", "9D",
        "10A", "10B", "10C", "10D", "11A", "11B", "11E", "11C", "11D"
    };

    public static readonly string[] Cities = new string[]
    {
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
}