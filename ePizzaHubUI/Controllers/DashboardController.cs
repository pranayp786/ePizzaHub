using ePizzaHubUI.Models.APiModels.Response;
using Microsoft.AspNetCore.Mvc;

namespace ePizzaHubUI.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public DashboardController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient("ePizzaAPI");

            var items = await client.GetFromJsonAsync<ApiResponseModel<IEnumerable<ItemResponseModel>>>("Item");

            if (items.Success)
            {
                return View(items.Data);
            }
            return View();
        }
    }
}
