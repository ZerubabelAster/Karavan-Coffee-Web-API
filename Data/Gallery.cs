namespace KaravanCoffeeWebAPI.Data
{
    public class Gallery
    {
        public int GalleryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; } // Type = {Event, Location, Food, Hero Section}
                                         // Event = {Birthday, Graduation, Karavan-Organized, 3rd Party-Organized, ...}
                                         // Location (just a place to hold lots photos of karavan coffee branch images)
        public DateTime UploadDateTime { get; set; }
        public string ImagePath { get; set; }
    }
}
