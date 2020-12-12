using System.Linq;
using System.Text.Json;
using ServerFramework.Authorization;
using ServerFramework.Authorization.AuthRoles;
using ServerFramework.Services;

namespace ServerFramework.Logic
{
    /// <summary>
    /// This class handles the CRUD operations on the users.
    /// </summary>
    public class HandleUsers
    {
        private User user;
        private User userHandled;

        /// <summary>
        /// This method is to add a new user to the database.
        /// </summary>
        /// <param name="userParam">User parameter.</param>
        /// <param name="username">Username.</param>
        public void AddUser(User userParam, string username)
        {
            if (user.Roles.OfType<PickingManager>().Any())
            {
                GetUser(username);
                SocketServiceImpl socket = new SocketServiceImpl();
                string json = JsonSerializer.Serialize<User>(userParam);
                socket.AddUser(json);
            }
        }

        /// <summary>
        /// This method updates a user in the database.
        /// </summary>
        /// <param name="userParam">User parameter.</param>
        public void UpdateUser(User userParam)
        {
            if (user.Roles.OfType<PickingManager>().Any())
            {
                SocketServiceImpl socket = new SocketServiceImpl();
                string json = JsonSerializer.Serialize<User>(userParam);
                socket.UpdateUser(json);
            }
        }

        /// <summary>
        /// This method is to remove a user from the database.
        /// </summary>
        /// <param name="username">Username.</param>
        public void RemoveUser(string username)
        {
            if (user.Roles.OfType<PickingManager>().Any())
            {
                SocketServiceImpl socket = new SocketServiceImpl();
                string json = JsonSerializer.Serialize<string>(username);
                socket.RemoveUser(json);
            }
        }

        /// <summary>
        /// GET method for the users.
        /// </summary>
        /// <param name="username">Username.</param>
        public User GetUser(string username)
        {
            SocketServiceImpl socket = new SocketServiceImpl();
            string json = JsonSerializer.Serialize<string>(username);
            User user = socket.GetUser(json);
            return user;
        }
    }
}