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
        private User user;

        /// <summary>
        /// This method will assign a recently received item to a location.
        /// </summary>
        /// <param name="item">Recently received item.</param>
        /// <param name="id">Location ID.</param>
        public void AllocatePutaway(Item item, string id)
        {
            if (user.Roles.OfType<InboundManager>().Any())
            {
                GetLocationByFullId(id);
                location.Item = item;
                if (location.Checksum == 0)
                {
                    SocketServiceImpl socket = new SocketServiceImpl();
                    string json = JsonSerializer.Serialize<Location>(location);
                    //socket.AllocatePutaway(json);
                }
            }
        }
        
        /// <summary>
        /// Creates a new location.
        /// </summary>
        /// <param name="id">Location ID.</param>
        public void CreateLocation(string id)
        {
            if (user.Roles.OfType<InboundManager>().Any())
            {
                GetLocationByFullId(id);
                Location temp = location;
                SocketServiceImpl socket = new SocketServiceImpl();
                string json = JsonSerializer.Deserialize<string>(id);
                socket.CreateLocation(json);
            }
        }

        /// <summary>
        /// Deletes the presently selected location.
        /// </summary>
        /// <param name="id">Location ID.</param>
        public void DeleteLocation(string id)
        {
            if (user.Roles.OfType<InboundManager>().Any())
            {
                SocketServiceImpl socket = new SocketServiceImpl();
                string json = JsonSerializer.Serialize<string>(id);
                socket.DeleteLocation(json);
            }
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
            if (user.Roles.OfType<InboundManager>().Any())
            {
                SocketServiceImpl socket = new SocketServiceImpl();
                string json = JsonSerializer.Serialize<Location>(loc);
                socket.UpdateLocation(json);
            }
        }

        /// <summary>
        /// This method would be called when the amount of an item reaches a minimum limit and have to be restocked on the location.
        /// </summary>
        /// <param name="id">Location ID.</param>
        public void ReplenishLocation(string id)
        {
            // Impl needed
        }

        /// <summary>
        /// Gets location based on its ID.
        /// </summary>
        /// <param name="id">Location ID.</param>
        public void GetLocationByFullId(string id)
        {
            string[] arr = id.Split("-");
            location = new Location(arr[2], arr[1], arr[0]);
            //take out before release
            System.Diagnostics.Debug.WriteLine(location.getFullId());
            //take out before release
        }
    }
}