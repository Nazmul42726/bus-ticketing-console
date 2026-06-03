using System.Collections.Generic;
using bus_ticketing_console.Models;

namespace bus_ticketing_console.Interfaces;

public interface IUserManager
{
    void CreateUser(User user);
    List<User> ShowUsers();
    bool IsValidUserId(string userId);
}