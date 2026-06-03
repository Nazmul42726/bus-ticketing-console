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