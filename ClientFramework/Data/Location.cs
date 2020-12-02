using System;
namespace ClientFramework.Data
{
    /// <summary>
    /// Class for storing warehouse locations. Stores location data, item on location and (optionally) a checksum to verify correct location.
    /// </summary>
    public class Location
    {
        private string number, line, area;
        private Item item;
        private int checksum;

        public Item Item { get => item; set => item = value; }
        public int Checksum { get => checksum; set => checksum = value; }
        public string Number { get => number; set => number = value; }
        public string Line { get => line; set => line = value; }
        public string Area { get => area; set => area = value; }

        public Location(string number, string line, string area)
        {
            this.number = number;
            this.line = line;
            this.area = area; 
        }

        /// <summary>
        /// Gets the full ID of the location.
        /// </summary>
        /// <returns>Returns the full ID of the location, in the format area-line-number.</returns>
        public string getFullId()
        {
            return area + "-" + line + "-" + number;
        }

    }
}
