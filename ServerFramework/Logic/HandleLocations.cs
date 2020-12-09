using System.Linq;
using ServerFramework.Authorization;
using ServerFramework.Authorization.AuthRoles;
using ServerFramework.Data;

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
                //Database connectivity comes here!!!
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
                //Database upload comes here
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
                //Database upload comes here
            }
        }

        /// <summary>
        /// Get all the locations from the database.
        /// </summary>
        /// <param name="id">Location ID.</param>
        public void GetLocation(string id)
        {
            
        }

        /// <summary>
        /// The locations can be edited through this method.
        /// </summary>
        /// <param name="loc">Location object.</param>
        public void UpdateLocation(Location loc)
        {
            
        }

        /// <summary>
        /// This method would be called when the amount of an item reaches a minimum limit and have to be restocked on the location.
        /// </summary>
        /// <param name="id">Location ID.</param>
        public void ReplenishLocation(string id)
        {
            
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