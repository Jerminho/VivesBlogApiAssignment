using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivesBlog.Dto.Requests;
using VivesBlog.Dto.Results;

namespace VivesBlog.Services.Extensions.Validation
{
    public static class ArticleValidator
    {
        public static void Validate(this ServiceResult<ArticleResult> serviceResult, ArticleRequest request)
        {
            // Validate Title
            if (string.IsNullOrWhiteSpace(request.Title))
            {
                serviceResult.NotEmpty(nameof(request.Title));
            }

            // Validate Content
            if (string.IsNullOrWhiteSpace(request.Content))
            {
                serviceResult.NotEmpty(nameof(request.Content));
            }

            // Validate Description
            if (string.IsNullOrWhiteSpace(request.Description))
            {
                serviceResult.NotEmpty(nameof(request.Description));
            }
        }
    }
}
