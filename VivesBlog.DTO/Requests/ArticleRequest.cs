using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VivesBlog.Dto.Requests
{
    public class ArticleRequest
    {
        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Content { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        public int? AuthorId { get; set; }
    }
}
