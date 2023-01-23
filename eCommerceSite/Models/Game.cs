using System.ComponentModel.DataAnnotations;

namespace eCommerceSite.Models
{
    /// <summary>
    /// Represents a single game for sale
    /// </summary>
    public class Game
    {
        /// <summary>
        /// The unique ID of the game
        /// </summary>
        [Key]
        public int GameID { get; set; }

        /// <summary>
        /// The name of the game
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// The MSRP price of the game
        /// </summary>
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        
        // TODO: Add Rating
    }
}
