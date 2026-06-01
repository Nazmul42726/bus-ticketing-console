using bus_ticketing_console.Interfaces;
using bus_ticketing_console.Models;

namespace bus_ticketing_console.Services;

public class UserService: IUserManager
{  
    private readonly List<User> _userList = new List<User>();
    private int _totalUser = 0;
    public void CreateUser(User user)
    {   
        user.UserId = $"USR-{_totalUser:X3}";
        _totalUser++;
        _userList.Add(user);
    }

    public List<User> ShowUsers()
    {
        return _userList;
    }
}