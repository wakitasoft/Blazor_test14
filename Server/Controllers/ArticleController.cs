using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor_test14.Server.Services;
using Blazor_test14.Shared;
using Microsoft.AspNetCore.Mvc;


namespace Blazor_test14.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Article>>> GetAllArticles()
        {
            return Ok(await _articleService.GetAllData());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> Get(int id)
        {
            return Ok(await _articleService.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Article entity)
        {
            return Ok(await _articleService.Post(entity));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Article entity)
        {
            return Ok(await _articleService.Put(id, entity));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await _articleService.Delete(id));
        }
    }
}
