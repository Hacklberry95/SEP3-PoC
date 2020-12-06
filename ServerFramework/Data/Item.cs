namespace ServerFramework.Data
{
    ///<summary>
    /// Class that stores items
    /// </summary>
    public class Item
    {
        private int id;
        public int Id
        {
            get => id;
            set => id = value;
        }

        private string name;

        public string Name
        {
            get => name;
            set => name = value;
        }

        private float weight;

        public float Weight
        {
            get => weight;
            set => weight = value;
        }

        private float width;

        public float Width
        {
            get => width;
            set => width = value;
        }

        private float length;

        public float Length
        {
            get => length;
            set => length = value;
        }

        private float height;

        public float Height
        {
            get => height;
            set => height = value;
        }

        private string description;

        public string Description
        {
            get => description;
            set => description = value;
        }

        /// <summary>
        /// Volume method calculates the volume based on the dimensions for shipping services
        /// </summary>
        /// <returns>Returns the volume of the item</returns>
        
        private float Volume()
        {
            return width * length * height;
        }
        /// <summary>
        /// Constructor for the Item class
        /// </summary>
        /// <param name="name">The name of the item.</param>
        /// <param name="weight">The weight of the item in kilograms (kg).</param>
        /// <param name="width">The width of the item to calculate volume.</param>
        /// <param name="length">The length of the item to calculate volume.</param>
        /// <param name="height">The height of the item to calculate volume.</param>
        /// <param name="description">The description of the item.</param>
        public Item(string name, float weight, float width, float length, float height, string description)
        {
            this.name = name;
            this.weight = weight;
            this.width = width;
            this.length = length;
            this.height = height;
            this.description = description;
        }

        /// <summary>
        /// Finishes setup of the Item class. WARNING: call immediately after server gets the ID for the Item added to the database.
        /// </summary>
        /// <param name="id">The ID of the item, got from the database.</param>
        public void Setup(int id)
        {
            this.id = id;
        }
    }
}