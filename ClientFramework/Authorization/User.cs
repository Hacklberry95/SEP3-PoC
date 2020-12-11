using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientFramework.Authorization
{
    /// <summary>
    /// Class to store user logins. 
    /// </summary>
    public class User

    {
    private string username, password;
    private List<Role> roles;

    public User(string username, string password)
    {
        this.username = username;
        this.password = password;
    }

    public User()
    {
        username = "";
        password = "";
    }

    public string Username
    {
        get => username;
        set => username = value;
    }

    public string Password
    {
        get => password;
        set => password = value;
    }

    public List<Role> Roles
    {
        get => roles;
        set => roles = value;
    }
    }
}
