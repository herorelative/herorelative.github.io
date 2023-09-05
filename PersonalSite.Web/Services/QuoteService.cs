using PersonalSite.Web.Models;
using System.Net.Http.Json;

namespace PersonalSite.Web.Services
{
    public interface IQuoteService
    {
        Task<QuoteItem> GetQuoteItemAsync();
    }

    public class QuoteService : IQuoteService
    {
        private readonly HttpClient _client;
        public QuoteService(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("quote");
        }
        public async Task<QuoteItem> GetQuoteItemAsync()
        {
            var result = await _client.GetFromJsonAsync<QuoteItem>("/random");

            result ??= new()
            {
                Content = "A winner is a dreamer who never gives up.",
                Author = "Nelson Mandela"
            };

            return result;
        }
    }
}
