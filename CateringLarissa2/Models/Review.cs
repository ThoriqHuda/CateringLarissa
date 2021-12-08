using System.ComponentModel.DataAnnotations;

namespace CateringLarissa2.Models
{
    public class Review
    {
        public int id { get; set; }

        [Required]

        public string title { get; set; }
        public string? description { get; set; }
        public string user { get; set; }

        [Range(1, 5)]
        [Required]
        public int rating { get; set; }

        public DateTime CreatedDate { get; set; }
#pragma warning disable CS8618 // Non-nullable property 'user' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'title' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public Review()
#pragma warning restore CS8618 // Non-nullable property 'title' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning restore CS8618 // Non-nullable property 'user' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        {

            this.CreatedDate = DateTime.Now;


        }
    }
}
