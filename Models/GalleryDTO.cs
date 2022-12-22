using KaravanCoffeeWebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace KaravanCoffeeWebAPI.Data
{
    public class CreateGalleryDTO
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        [Required]
        public string Type { get; set; } // Type = {Event, Location, Food, Hero Section}
                                         // Event = {Birthday, Graduation, Karavan-Organized, 3rd Party-Organized, ...}
                                         // Location (a type which is needed just to hold lots photos of karavan coffee branch images under it)
        public DateTime UploadDateTime { get; set; }
        public List<string> ImagePath { get; set; }
    }
    public class GalleryDTO : CreateGalleryDTO
    {
        public int GalleryId { get; set; }
    }
}
