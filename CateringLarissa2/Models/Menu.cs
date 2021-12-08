namespace CateringLarissa2.Models
{
    public class Menu
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int price { get; set; }

        public string menuimage { get; set; }

#pragma warning disable CS8618 // Non-nullable property 'description' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'title' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'menuimage' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public Menu()
#pragma warning restore CS8618 // Non-nullable property 'menuimage' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning restore CS8618 // Non-nullable property 'title' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning restore CS8618 // Non-nullable property 'description' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        {

        }
    }
}
