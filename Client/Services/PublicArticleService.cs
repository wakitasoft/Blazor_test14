using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Blazor_test14.Client.Util;
using Blazor_test14.Shared;

namespace Blazor_test14.Client.Services
{
    public interface IPublicArticleService
    {
        Task<List<Article>> GetAllArticles();
        Task<Article> Get(int id);
        Task<int> Post(Article entity);
        Task<HttpResponseMessage> Put(int id, Article entity);
        Task<HttpResponseMessage> Delete(int id);
    }

    public class PublicArticleService : IPublicArticleService
    {
        private readonly HttpClient _http;

        public PublicArticleService(PublicClient http)
        {
            _http = http.Client;
        }

        public async Task<List<Article>> GetAllArticles()
        {
            var options = new JsonSerializerOptions
            {
                ReadCommentHandling = JsonCommentHandling.Skip,
                AllowTrailingCommas = true,
                PropertyNameCaseInsensitive = true
            };
            return await _http.GetFromJsonAsync<List<Article>>("api/Article", options);
        }
        public async Task<Article> Get(int id)
        {
            var options = new JsonSerializerOptions
            {
                ReadCommentHandling = JsonCommentHandling.Skip,
                AllowTrailingCommas = true,
                PropertyNameCaseInsensitive = true
            };
            return await _http.GetFromJsonAsync<Article>($"api/Article/{id}", options);
        }

        public async Task<int> Post(Article entity)
        {
            var result = await _http.PostAsJsonAsync("api/Article", entity);
            string id = await result.Content.ReadAsStringAsync();
            return int.Parse(id);
        }

        public async Task<HttpResponseMessage> Put(int id, Article entity)
        {
            return await _http.PutAsJsonAsync($"api/Article/{id}", entity);
        }

        public async Task<HttpResponseMessage> Delete(int id)
        {
            return await _http.DeleteAsync($"api/Article/{id}");
        }
    }
}
