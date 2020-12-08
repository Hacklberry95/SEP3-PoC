using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ClientFramework.Data
{
    ///<summary>
    /// Class that stores items
    /// </summary>
    public class Item
    {
        [Required(ErrorMessage = "Id is required,!")]
        private int id;
        public int Id
        {
            get => id;
            set => id = value;
        }
        [Required (ErrorMessage = "Name is required!")]
        private string name;

        public string Name
        {
            get => name;
            set => name = value;
        }
        [Range(0.0001, 1000, ErrorMessage = "Value for {0} must be between {1} and {2} mm.")]
        private float weight;

        public float Weight
        {
            get => weight;
            set => weight = value;
        }
        [Range(1, 3000, ErrorMessage = "Value for {0} must be between {1} and {2} mm.")]
        private float width;

        public float Width
        {
            get => width;
            set => width = value;
        }
        [Range(1, 3000, ErrorMessage = "Value for {0} must be between {1} and {2} mm.")]
        private float length;

        public float Length
        {
            get => length;
            set => length = value;
        }
        [Range(1, 3000, ErrorMessage = "Value for {0} must be between {1} and {2} mm.")]
        private float height;

        public float Height
        {
            get => height;
            set => height = value;
        }
        [MaxLength(128, ErrorMessage = "Must not be over {1}.")]
        private string description;
        
        public string Description
        {
            get => description;
            set => description = value;
        }
        [Required, Range(1, 500, ErrorMessage = "Cannot receive more than {2} at a time.")]
        private int stock;

        public int Stock
        {
            get => stock;
            set => stock = value;
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
        /// Constructor for the Item class (New Items)
        /// </summary>
        /// <param name="name">The name of the item.</param>
        /// <param name="weight">The weight of the item in kilograms (kg).</param>
        /// <param name="width">The width of the item to calculate volume.</param>
        /// <param name="length">The length of the item to calculate volume.</param>
        /// <param name="height">The height of the item to calculate volume.</param>
        /// <param name="description">The description of the item.</param>
        /// <param name="stock">The amount of items available.</param>
        public Item(string name, float weight, float width, float length, float height, string description, int stock)
        {
            this.name = name;
            this.weight = weight;
            this.width = width;
            this.length = length;
            this.height = height;
            this.description = description;
            this.stock = stock;
        }
        
        /// <summary>
        /// 2nd Constructor for the Item class (Existing Items)
        /// </summary>
        /// <param name="id">The unique id of an item.</param>
        /// <param name="name">The name of the item.</param>
        /// <param name="weight">The weight of the item in kilograms (kg).</param>
        /// <param name="width">The width of the item to calculate volume.</param>
        /// <param name="length">The length of the item to calculate volume.</param>
        /// <param name="height">The height of the item to calculate volume.</param>
        /// <param name="description">The description of the item.</param>
        /// <param name="stock">The amount of items available.</param>
        public Item(int id,string name, float weight, float width, float length, float height, string description, int stock)
        {
            this.id = id;
            this.name = name;
            this.weight = weight;
            this.width = width;
            this.length = length;
            this.height = height;
            this.description = description;
            this.stock = stock;
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