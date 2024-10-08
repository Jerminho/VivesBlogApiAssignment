using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VivesBlog.Dto.Results
{
    public class PersonResult
    {
        public int Id { get; set; }

        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public string? Email { get; set; }

        // List of articles the person has authored
        public List<ArticleResult>? Articles { get; set; }
    }
}
