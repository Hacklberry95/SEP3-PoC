using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using ServerFramework.Authorization;
using ServerFramework.Authorization.AuthRoles;
using ServerFramework.Data;
using ServerFramework.Services;

namespace ServerFramework.Logic
{
    public class HandleLocations
    {
        private Location location;

        /// <summary>
        /// This method will assign a recently received item to a location.
        /// </summary>
        /// <param name="item">Recently received item.</param>
        /// <param name="id">Location ID.</param>
        public void AllocatePutaway(Item item, string id)
        {
            GetLocationByFullId(id);
            location.Item = item;
            SocketServiceImpl socket = new SocketServiceImpl();
            string json = JsonSerializer.Serialize<Location>(location);
            socket.AllocatePutaway(json);
        }
        
        /// <summary>
        /// Creates a new location.
        /// </summary>
        /// <param name="id">Location ID.</param>
        public void CreateLocation(string id)
        {
                SocketServiceImpl socket = new SocketServiceImpl();
                string json = JsonSerializer.Deserialize<string>(id);
                socket.CreateLocation(json);
        }

        /// <summary>
        /// Deletes the presently selected location.
        /// </summary>
        /// <param name="id">Location ID.</param>
        public void DeleteLocation(string id)
        {
                SocketServiceImpl socket = new SocketServiceImpl();
                string json = JsonSerializer.Serialize<string>(id);
                socket.DeleteLocation(json);
        }

        /// <summary>
        /// Get all the locations from the database.
        /// </summary>
        /// <param name="id">Location ID.</param>
        public Location GetLocation(string id)
        {
            SocketServiceImpl socket = new SocketServiceImpl();
            string json = JsonSerializer.Serialize<string>(id);
            Location location = socket.GetLocation(json);
            return location;
        }

        /// <summary>
        /// The locations can be edited through this method.
        /// </summary>
        /// <param name="loc">Location object.</param>
        public void UpdateLocation(Location loc)
        {
            SocketServiceImpl socket = new SocketServiceImpl();
            string json = JsonSerializer.Serialize<Location>(loc);
            socket.UpdateLocation(json);
        }

        /// <summary>
        /// This method would be called when the amount of an item reaches a minimum limit and have to be restocked on the location.
        /// </summary>
        /// <param name="id">Location ID.</param>
        /// <returns>A List of all locations to be replenished.</returns>
        public List<string> ReplenishLocation(string id)
        {
            // Impl needed: send it to client -> update replenish location
            SocketServiceImpl socket = new SocketServiceImpl();
            List<string> list = socket.ReplenishLocation(id);
            return list;
        }

        /// <summary>
        /// Gets location based on its ID.
        /// </summary>
        /// <param name="id">Location ID.</param>
        public void GetLocationByFullId(string id)
        {
            string[] arr = id.Split("-");
            location = new Location(arr[2], arr[1], arr[0]);
        }
    }
}