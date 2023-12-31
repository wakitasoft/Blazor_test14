using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor_test14.Server.Data;
using Blazor_test14.Shared;
using Microsoft.EntityFrameworkCore;

namespace Blazor_test14.Server.Services
{
    public interface IArticleService
    {
        Task<List<Article>> GetAllData();
        Task<Article> Get(int id);
        Task<int> Post(Article entity);
        Task<int> Put(int id, Article entity);
        Task<int> Delete(int id);
    }
    public class ArticleService : IArticleService
    {
        private readonly DataContext _context;

        public ArticleService(IDbContextFactory<DataContext> context)
        {
            _context = context.CreateDbContext();
        }

        public async Task<List<Article>> GetAllData()
        {
            using (_context)
            {
                return await _context.Articles.ToListAsync();
            }
        }

        public async Task<Article> Get(int id)
        {
            using (_context)
            {
                return await _context.Articles.FirstOrDefaultAsync(x => x.Id == id);
            }
        }
        public async Task<int> Post(Article entity)
        {
            using (_context)
            {
                DateTime now = DateTime.Now;
                entity.CreateDate = now;
                entity.UpdateDate = now;
                await _context.Articles.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity.Id;
            }
        }

        public async Task<int> Put(int id, Article entity)
        {
            using (_context)
            {
                var _entity = _context.Articles.FirstOrDefault(x => x.Id == id);
                _entity.Title = entity.Title;
                _entity.Content = entity.Content;
                _entity.UpdateDate = DateTime.Now;
                return await _context.SaveChangesAsync();
            }
        }

        public async Task<int> Delete(int id)
        {
            using (_context)
            {
                var _entity = _context.Articles.FirstOrDefault(x => x.Id == id);
                _context.Articles.Remove(_entity);
                return await _context.SaveChangesAsync();
            }
        }
    }
}
