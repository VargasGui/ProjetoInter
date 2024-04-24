using ISoccer.Infra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISoccer.Service.Interfaces
{
    public interface INewsService
    {
        Task<bool> CreateNews(NewsDTO newsDto);
        Task<List<NewsDTO>> GetAllNews();
    }
}
