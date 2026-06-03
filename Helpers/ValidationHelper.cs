using System.Text.RegularExpressions;

namespace bus_ticketing_console.Helpers;

public class ValidationHelper
{
    public static bool IsValidName(string name)
    {
        // 1. Check if empty
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[!] Name cannot be empty.");
            Console.ResetColor();
            return false;
        }
        // 2. Check length constraint
        if (name.Length > 150)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[!] Name is too long! It cannot be longer than 150 characters.");
            Console.ResetColor();
            return false;
        }
        // 3. Check for invalid characters
        foreach (char c in name)
        {
            if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[!] Invalid name! It cannot contain digits or special characters.");
                Console.ResetColor();
                return false;
            }
        }
        return true;
    }

    public static bool IsValidMobileNumber(string mobileNumber)
    {
        // 1. Check if empty
        if (string.IsNullOrWhiteSpace(mobileNumber))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[!] Mobile number cannot be empty.");
            Console.ResetColor();
            return false;
        }
        string cleanedNumber = mobileNumber.Trim();
        int validNumberLength = 4;                  //for easier testing, keep lenght short
        // 2. Check length constraint
        if (cleanedNumber.Length != validNumberLength)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[!] Mobile Number must be exactly {validNumberLength} digits long.");
            Console.ResetColor();
            return false;
        }
        // 3. Check for invalid characters
        foreach (char c in cleanedNumber)
        {
            if (!char.IsDigit(c))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[!] Invalid Mobile Number! It can only contain digits.");
                Console.ResetColor();
                return false;
            }
        }
        return true;
    }
    public static bool IsValidEmail(string email)
    {
        // 1. Check if empty
        if (string.IsNullOrWhiteSpace(email))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[!] Email address cannot be empty.");
            Console.ResetColor();
            return false;
        }

        string cleanedEmail = email.Trim();

        // 2. Validate email structure 
        string emailPattern = @"^[^@\s]+@[^@\s]+\.[a-zA-Z]{1,6}$";
        
        if (!Regex.IsMatch(cleanedEmail, emailPattern))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[!] Invalid Email format! Example format: user@example.com");
            Console.ResetColor();
            return false;
        }
        return true;
    }
}