using ePizzaHub.Models.ApiModels.Response;
namespace ePizzaHub.Core.Contracts
{
    public interface IItemService
    {
        Task<IEnumerable<GetItemResponse>> GetItemsAsync();
    }
}
