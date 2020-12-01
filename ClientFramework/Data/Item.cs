namespace ClientFramework.Data
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

        private double weight;

        public double Weight
        {
            get => weight;
            set => weight = value;
        }

        private double width;

        public double Width
        {
            get => width;
            set => width = value;
        }

        private double length;

        public double Length
        {
            get => length;
            set => length = value;
        }

        private double height;

        public double Height
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
        
        private double Volume()
        {
            return width * length * height;
        }
        /// <summary>
        /// Constructor for the Item class
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="weight"></param>
        /// <param name="width"></param>
        /// <param name="length"></param>
        /// <param name="height"></param>
        /// <param name="description"></param>
        public Item(string name, double weight, double width, double length, double height, string description)
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
        /// <param name="id"></param>
        public void Setup(int id)
        {
            this.id = id;
        }
    }
}