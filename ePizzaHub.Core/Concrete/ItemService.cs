﻿using AutoMapper;
using ePizzaHub.Core.Contracts;
using ePizzaHub.Models.ApiModels.Response;
using ePizzaHub.Repositories.Contracts;


namespace ePizzaHub.Core.Concrete
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public ItemService(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<GetItemResponse>> GetItemsAsync()
        {
            var items = _itemRepository.GetAll();

            var response = _mapper.Map<IEnumerable<GetItemResponse>>(items);

            return response;
        }
    }
}
