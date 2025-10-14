using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YummyWebUI.Dtos.EventDtos;

namespace YummyWebUI.ViewComponents
{
    public class _EventDefaultPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _EventDefaultPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7113/api/YummyEvents/");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultEventDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
