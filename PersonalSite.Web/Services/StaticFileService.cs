using PersonalSite.Web.Models;
using System.Net.Http.Json;
namespace PersonalSite.Web.Services
{
    public interface IStaticFileService
    {
        Task<ExperienceItem[]> GetExperienceAsync();
        Task<TestimonialItem[]> GetTestimonialAsync();
        Task<ResourceItem[]> GetResourceAsync();
    }

    public sealed class StaticFileService : IStaticFileService
    {
        private readonly HttpClient _client;
        public StaticFileService(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("static");
        }

        public async Task<ExperienceItem[]> GetExperienceAsync()
        {
            return await _client.GetFromJsonAsync<ExperienceItem[]>("sample-data/experiences.json");
        }

        public async Task<TestimonialItem[]> GetTestimonialAsync()
        {
            return await _client.GetFromJsonAsync<TestimonialItem[]>("sample-data/testimonials.json");
        }

        public async Task<ResourceItem[]> GetResourceAsync()
        {
            return await _client.GetFromJsonAsync<ResourceItem[]>("sample-data/test-data.json");
        }
    }
}
