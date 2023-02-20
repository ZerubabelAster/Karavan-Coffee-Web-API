using AutoMapper;
using KaravanCoffeeWebAPI.Data;
using KaravanCoffeeWebAPI.Models;

namespace KaravanCoffeeWebAPI.Configration
{
    public class MapperInitilizer : Profile
    {
        public MapperInitilizer()
        {
            CreateMap<Person, PersonDTO>().ReverseMap();
            /*CreateMap<Person, PersonDTO>().ReverseMap();*/

            CreateMap<Branch, BranchDTO>().ReverseMap();
            CreateMap<Branch, CreateBranchDTO>().ReverseMap();

            CreateMap<LoyalityDetail, LoyalityDetailDTO>().ReverseMap();
            CreateMap<LoyalityDetail, CreateLoyalityDetailDTO>().ReverseMap();

            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Order, CreateOrderDTO>().ReverseMap();

            CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap();
            CreateMap<OrderDetail, CreateOrderDetailDTO>().ReverseMap();

            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, CreateProductDTO>().ReverseMap();

            CreateMap<ProductAvailability, ProductAvailabilityDTO>().ReverseMap();
            CreateMap<ProductAvailability, CreateProductAvailabilityDTO>().ReverseMap();

            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();

            CreateMap<SubCategory, SubCategoryDTO>().ReverseMap();
            CreateMap<SubCategory, CreateSubCategoryDTO>().ReverseMap();

            CreateMap<Gallery, GalleryDTO>().ReverseMap();
            CreateMap<Gallery, CreateGalleryDTO>().ReverseMap();

            CreateMap<Ingredient, IngredientDTO>().ReverseMap();
            CreateMap<Ingredient, CreateIngredientDTO>().ReverseMap();
        }
    }
}
