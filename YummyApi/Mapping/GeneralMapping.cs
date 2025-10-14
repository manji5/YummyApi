using AutoMapper;
using YummyApi.Dtos.CategoryDtos;
using YummyApi.Dtos.ChefDtos;
using YummyApi.Dtos.EventDtos;
using YummyApi.Dtos.FeatureDtos;
using YummyApi.Dtos.MessageDtos;
using YummyApi.Dtos.ProductDtos;
using YummyApi.Dtos.ServiceDtos;
using YummyApi.Dtos.TestimonialDtos;
using YummyApi.Entities;

namespace YummyApi.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDto>().ReverseMap();

            CreateMap<Chef, ResultChefDto>().ReverseMap();
            CreateMap<Chef, CreateChefDto>().ReverseMap();
            CreateMap<Chef, UpdateChefDto>().ReverseMap();
            CreateMap<Chef, GetByIdChefDto>().ReverseMap();

            //Contact

            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();

            CreateMap<Message, ResultMessageDto>().ReverseMap();
            CreateMap<Message, CreateMessageDto>().ReverseMap();
            CreateMap<Message, UpdateFeatureDto>().ReverseMap();
            CreateMap<Message, GetByIdMessageDto>().ReverseMap();

            CreateMap<Product, ResultProductDto>().ForMember(x => x.CategoryName, y => y.MapFrom(z => z.Category.CategoryName)).ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();

            CreateMap<Service, ResultServiceDto>().ReverseMap();
            CreateMap<Service, CreateServiceDto>().ReverseMap();
            CreateMap<Service, UpdateServiceDto>().ReverseMap();
            CreateMap<Service, GetByIdServiceDto>().ReverseMap();

            CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, GetByIdTestimonialDto>().ReverseMap();

            CreateMap<YummyEvent, ResultEventDto>().ReverseMap();
            CreateMap<YummyEvent, CreateEventDto>().ReverseMap();
            CreateMap<YummyEvent, UpdateEventDto>().ReverseMap();
            CreateMap<YummyEvent, GetByIdEventDto>().ReverseMap();
        }
    }
}
