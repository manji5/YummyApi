using AutoMapper;
using YummyApi.Dtos.FeatureDtos;
using YummyApi.Dtos.MessageDtos;
using YummyApi.Entities;

namespace YummyApi.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();

            CreateMap<Message, ResultMessageDto>().ReverseMap();
            CreateMap<Message, CreateMessageDto>().ReverseMap();
            CreateMap<Message, UpdateFeatureDto>().ReverseMap();
            CreateMap<Message, GetByIdMessageDto>().ReverseMap();

        }
    }
}
