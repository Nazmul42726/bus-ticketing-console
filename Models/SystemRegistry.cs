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

    public static readonly List<string> Seats28 = new List<string>
    {
        "1A", "1B", "1C", "2A", "2B", "2C", "3A", "3B", "3C", "4A", "4B", "4C",
        "5A", "5B", "5C", "6A", "6B", "6C", "7A", "7B", "7C", "8A", "8B", "8C",
        "9A", "9E", "9B", "9C"
    };

    public static readonly List<string> Seats30 = new List<string>
    {
        "1A", "1B", "1C", "2A", "2B", "2C", "3A", "3B", "3C", "4A", "4B", "4C",
        "5A", "5B", "5C", "6A", "6B", "6C", "7A", "7B", "7C", "8A", "8B", "8C",
        "9A", "9B", "9C", "10A", "10B", "10C"
    };

    public static readonly List<string> Seats32 = new List<string>
    {
        "1B", "1C", "2A", "2B", "2C", "3A", "3B", "3C", "4A", "4B", "4C",
        "5A", "5B", "5C", "6A", "6B", "6C", "7A", "7B", "7C", "8A", "8B", "8C",
        "9A", "9B", "9C", "10A", "10B", "10C", "11A", "11B", "11C"
    };

    public static readonly List<string> Seats36 = new List<string>
    {
        "1A", "1B", "1C", "1D", "2A", "2B", "2C", "2D", "3A", "3B", "3C", "3D",
        "4A", "4B", "4C", "4D", "5A", "5B", "5C", "5D", "6A", "6B", "6C", "6D",
        "7A", "7B", "7C", "7D", "8A", "8B", "8C", "8D", "9A", "9B", "9C", "9D"
    };

    public static readonly List<string> Seats40 = new List<string>
    {
        "1A", "1B", "1C", "1D", "2A", "2B", "2C", "2D", "3A", "3B", "3C", "3D",
        "4A", "4B", "4C", "4D", "5A", "5B", "5C", "5D", "6A", "6B", "6C", "6D",
        "7A", "7B", "7C", "7D", "8A", "8B", "8C", "8D", "9A", "9B", "9C", "9D",
        "10A", "10B", "10C", "10D"
    };

    public static readonly List<string> Seats45 = new List<string>
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

    public static List<string[]> BusModelsList()
    {
        List<string[]> busModelsList = new List<string[]>();
        for (int i = 0; i < BusModels.Length; i++)
        {
            busModelsList.Add(new string[] { (i + 1).ToString(), BusModels[i] });
        }
        return busModelsList;
    }

    public static List<string[]> BusClassList()
    {
        List<string[]> busClassList = new List<string[]>();
        for (int i = 0; i < BusClass.Length; i++)
        {
            busClassList.Add(new string[] { (i + 1).ToString(), BusClass[i] });
        }
        return busClassList;
    }

    public static List<string[]> CapacityList(bool isBusiness)
    {
        List<string[]> capacityList = new List<string[]>();
        string[] target = isBusiness ? BusinessCapacities : EconomyCapacities;
        for (int i = 0; i < target.Length; i++)
        {
            capacityList.Add(new string[] { (i + 1).ToString(), target[i] });
        }
        return capacityList;
    }

    public static List<string[]> AcOptionsList()
    {
        List<string[]> acList = new List<string[]>();
        for (int i = 0; i < AcOptions.Length; i++)
        {
            acList.Add(new string[] { (i + 1).ToString(), AcOptions[i] });
        }
        return acList;
    }

    public static List<string[]> CitiesList()
    {
        List<string[]> citiesList = new List<string[]>();
        for (int i = 0; i < Cities.Length; i++)
        {
            citiesList.Add(new string[] { (i + 1).ToString(), Cities[i] });
        }
        return citiesList;
    }
}