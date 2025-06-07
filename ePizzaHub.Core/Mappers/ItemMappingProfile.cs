using AutoMapper;
using ePizzaHub.Models.ApiModels.Response;
using ePizzHub.Infrastructure.Models;

namespace ePizzaHub.Core.Mappers
{
    public class ItemMappingProfile : Profile
    {
        public ItemMappingProfile()
        {
            CreateMap<Item, GetItemResponse>();
        }
    }
}
