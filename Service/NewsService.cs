using ISoccer.Infra.Data;
using ISoccer.Infra.Models;
using ISoccer.Service.DTO;
using ISoccer.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISoccer.Service
{
    public class NewsService : INewsService
    {
        private readonly AppDbContext _dataContext;

        public NewsService(AppDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> CreateNews(NewsDTO newsDto)
        {
            News news = new News()
            {
                Title= newsDto.Title,
                Description = newsDto.Description,
                Image = newsDto.Image,
                Date = newsDto.Date,
                Source= newsDto.Source,
                TeamId = newsDto.TeamId,

            };

            _dataContext.News.Add(news);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<NewsDTO>> GetAllNews()
        {
            var news = await _dataContext.News.ToListAsync();
            var newsDto = news.Select(x => new NewsDTO()
            {
                Title = x.Title,
                Description = x.Description,
                Image = x.Image,
                Date = x.Date,
                Source = x.Source,
                TeamId = x.TeamId,

            });
            return newsDto.ToList();
        }
    }
}
