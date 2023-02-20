using System.ComponentModel.DataAnnotations;

namespace KaravanCoffeeWebAPI.Models
{
    public class CreateGalleryDTO
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public IFormFile Image { get; set; }

        [StringLength(int.MaxValue)]
        public string ImagePath { get; set; }
    }

    public class UpdateGalleryDTO : CreateGalleryDTO
    {
    }

    public class GalleryDTO : CreateGalleryDTO
    {
        public int GalleryId { get; set; }
    }
}
