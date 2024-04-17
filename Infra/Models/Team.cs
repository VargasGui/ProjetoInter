using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISoccer.Infra.Models
{
    public class Team
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public List<News> NewsList { get; set; }
        
    }
}
