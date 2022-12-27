using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Xunit;
using Xunit.Sdk;

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

        [Required]
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
