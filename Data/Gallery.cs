using System.ComponentModel.DataAnnotations.Schema;

namespace KaravanCoffeeWebAPI.Data
{
    public class Gallery
    {
        public int GalleryId { get; set; }
        
        public string Title { get; set; }

        public string Description { get; set; }
        
        public string Type { get; set;}

        [NotMapped]
        public IFormFile Url { get; set; }

        public string ImagePath { get; set;}
    }
}
