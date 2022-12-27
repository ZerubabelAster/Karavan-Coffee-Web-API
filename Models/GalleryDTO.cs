using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Xunit;
using Xunit.Sdk;

{
    public class CreateGalleryDTO
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
    }

    public class GalleryDTO : CreateGalleryDTO
    {
        public int GalleryId { get; set; }
    }
}
