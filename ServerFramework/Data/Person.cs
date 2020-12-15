using ServerFramework.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerFramework.Data
{
    [Obsolete]
    /// <summary>
    /// Class to store persons. Stores name, id, and authorization roles.
    /// </summary>
    public class Person
    {
        private readonly string firstName, lastName;
        private int id;
        private User user;
        public string Firstname { get => firstName; }
        public string Lastname { get => lastName; }
        public int ID { get => id; set => id = value; }
        
        
        /// <summary>
        /// Constructor for the Person class. Also sets up login.
        /// </summary>
        /// <param name="firstName">The first name(s) of the person.</param>
        /// <param name="lastName">The last name(s) of the person.</param>
        /// <param name="username">The username to be used when logging in.</param>
        /// <param name="password">The password of the user.</param>
        public Person(string firstName, string lastName, string username, string password)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            user = new User();
            user.Username = username;
            user.Password = password;
        }

        /// <summary>
        /// Finishes setup of the Person class. WARNING: call immediately after server gets the ID for the Person added to the database.
        /// </summary>
        /// <param name="id">The ID of the person, got from the database.</param>
        public void Setup(int id)
        {
            this.id = id;  
        }
    }
}
