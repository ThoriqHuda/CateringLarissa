namespace CateringLarissa2.ViewModels
{
    public class MenuViewModel
    {
#pragma warning disable CS8618 // Non-nullable property 'title' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string title { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'title' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'description' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string description { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'description' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public int price { get; set; }
#pragma warning disable CS8618 // Non-nullable property 'menuimage' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public IFormFile menuimage  { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'menuimage' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
    }
}
