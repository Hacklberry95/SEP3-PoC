using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerFramework.Authorization
{
    /// <summary>
    /// Class to store user logins. 
    /// </summary>
    public class User
    {
        private string username, password;
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
    }
}
