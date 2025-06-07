﻿namespace ePizzaHub.Models.ApiModels.Response
{
    public class GetItemResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        public decimal UnitPrice { get; set; }

        public string ImageUrl { get; set; } = default!;

    }
}
