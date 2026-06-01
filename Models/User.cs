namespace bus_ticketing_console.Models;

public class User
{
    public string UserId {get; set;} = string.Empty;
    public required string UserName {get; set;}
    public required string MobileNumber {get; set;}
    public required string Email {get; set;}
}