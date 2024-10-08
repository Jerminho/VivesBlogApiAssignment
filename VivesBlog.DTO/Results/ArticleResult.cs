using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VivesBlog.Dto.Results
{
    public class ArticleResult
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime PublishedDate { get; set; }

        public int? AuthorId { get; set; }
        public string? AuthorName { get; set; }
    }
}
