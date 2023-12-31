using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Blazor_test14.Shared;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace Blazor_test14.Client.Services
{
    public interface IArticleService
    {
        Task<List<Article>> GetAllArticles();
        //PublicArticleService へ移動Task<int> Post(Article entity);
    }

    public class ArticleService : IArticleService
    {
        private readonly HttpClient _http;

        public ArticleService(HttpClient http)
        {
            _http = http;
        }
        public async Task<List<Article>> GetAllArticles()
        {
            return await _http.GetFromJsonAsync<List<Article>>("api/Article");
        }

        /* PublicArticleService へ移動
        public async Task<int> Post(Article entity)
        {
            var result = await _http.PostAsJsonAsync("api/Article", entity);
            string id = await result.Content.ReadAsStringAsync();
            return int.Parse(id);
            / *
            try
            {
                var options = new JsonSerializerOptions
                {
                    ReadCommentHandling = JsonCommentHandling.Skip,
                    AllowTrailingCommas = true,
                    PropertyNameCaseInsensitive = true
                };
                var result = await _http.PostAsJsonAsync("api/Article", entity, options);
                string id = await result.Content.ReadAsStringAsync();
                return int.Parse(id);
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return 0;
            }
            * /
        }
    */
}
}
