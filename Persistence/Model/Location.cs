using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Persistence.Model
{
    public class Location
    {
        //dont know how to limit warehouse size by another var
        [Required, Range(0, 255)] public int X { get; set; }
        [Required, Range(0, 255)] public int Y { get; set; }
        [Required, Range(0, 255)] public int Z { get; set; }

        [Key]
        public string LocationId
        {
            set { LocationId = value; }
            get
            {
                return X + "," + Y + "," + Z;
            }

        }
        public IList<Item> ItemsInside{ get; set; }
    }
}