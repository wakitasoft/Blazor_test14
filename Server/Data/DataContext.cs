using System;
using Blazor_test14.Shared;
using Microsoft.EntityFrameworkCore;

namespace Blazor_test14.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasData(
                new Article
                {
                    Id = 1,
                    Title = "タイトル1",
                    Content = "本文1",
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                },
                new Article
                {
                    Id = 2,
                    Title = "タイトル2",
                    Content = "本文2",
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                },
                new Article
                {
                    Id = 3,
                    Title = "タイトル3",
                    Content = "本文3",
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                }
           );
        }
    }
}
