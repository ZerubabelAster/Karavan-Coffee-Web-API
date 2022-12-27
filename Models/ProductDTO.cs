<<<<<<< Updated upstream
﻿using System.ComponentModel.DataAnnotations;
=======
﻿using AutoMapper.Configuration.Annotations;
using KaravanCoffeeWebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Xunit;
using Xunit.Sdk;
>>>>>>> Stashed changes

namespace KaravanCoffeeWebAPI.Models
{
    public class CreateProductDTO
    {
        [Required]
        public string ProductCode { get; set; }

        [Required]
        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        [Required]
<<<<<<< Updated upstream
        public string ProductCategory { get; set; }

        [Required]
        public string ProductSubCategory { get; set; }
        public string ImagePath { get; set; }

        [Required]
        public double UnitPrice { get; set; }
        public string Ingredients { get; set; }
        public string Extras { get; set; }
        [Required]
        public bool Orderable { get; set; }
        [Required]
        public bool Active { get; set; }
=======
        public double UnitPrice { get; set; }

        public string MainIngredients { get; set; } // Before: Keywords, comma separated

        [Required]
        public bool Active { get; set; }

        public bool RequireExtra { get; set; }

        [DefaultValue(0)]
>>>>>>> Stashed changes
        public double Discount { get; set; }
        public int ProductPoint { get; set; }

        [Range(1, 5)]
        public double Rating { get; set; }

        public int TotalOrdered { get; set; }
        public DateTime EPT { get; set; }
    }
    public class UpdateProductDTO : CreateProductDTO
    {

    }
    public class ProductDTO : CreateProductDTO
    {
        public int ProductId { get; set; }
    }
}
