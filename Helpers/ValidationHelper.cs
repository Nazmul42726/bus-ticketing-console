using System.Text.RegularExpressions;
using bus_ticketing_console.Interfaces;
using bus_ticketing_console.Models;

namespace bus_ticketing_console.Helpers;

public class ValidationHelper
{
    public static bool IsValidName(string name, out string errorMessage)
    {
        errorMessage = string.Empty;
        // 1. Check if empty
        if (string.IsNullOrWhiteSpace(name))
        {
            errorMessage = "Name cannot be empty";
            return false;
        }
        // 2. Check length constraint
        if (name.Length > 150)
        {
            errorMessage = "Name is too long! It cannot be longer than 150 characters";
            return false;
        }
        // 3. Check for invalid characters
        foreach (char c in name)
        {
            if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
            {
                errorMessage = "Invalid name! It cannot contain digits or special characters";
                return false;
            }
        }
        return true;
    }

    public static bool IsValidMobileNumber(string mobileNumber, out string errorMessage)
    {
        errorMessage = string.Empty;
        // 1. Check if empty
        if (string.IsNullOrWhiteSpace(mobileNumber))
        {
            errorMessage = "Mobile number cannot be empty";
            return false;
        }
        string cleanedNumber = mobileNumber.Trim();
        int validNumberLength = 4;                  //for easier testing, keep lenght short
        // 2. Check length constraint
        if (cleanedNumber.Length != validNumberLength)
        {
            errorMessage = $"Mobile Number must be exactly {validNumberLength} digits long";
            return false;
        }
        // 3. Check for invalid characters
        foreach (char c in cleanedNumber)
        {
            if (!char.IsDigit(c))
            {
                errorMessage = "Invalid Mobile Number! It can only contain digits";
                return false;
            }
        }
        return true;
    }
    public static bool IsValidEmail(string email, out string errorMessage)
    {
        errorMessage = string.Empty;
        // 1. Check if empty
        if (string.IsNullOrWhiteSpace(email))
        {
            errorMessage = "Email address cannot be empty";
            return false;
        }

        string cleanedEmail = email.Trim();

        // 2. Validate email structure 
        string emailPattern = @"^[^@\s]+@[^@\s]+\.[a-zA-Z]{1,6}$";
        
        if (!Regex.IsMatch(cleanedEmail, emailPattern))
        {
            errorMessage = "Invalid Email format! Example format: 'user@example.com'";
            return false;
        }
        return true;
    }

    public static bool IsValidSeat(string seat, ISeatLayoutStrategy seatLayout) => seatLayout.IsValidSeat(seat);
}