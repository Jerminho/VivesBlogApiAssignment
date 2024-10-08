using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivesBlog.Dto.Results;
using VivesBlog.Model;

namespace VivesBlog.Services.Extensions.Projection
{
    public static class PersonProjectionExtensions
    {

        public static IQueryable<ArticleResult> Project(this IQueryable<Article> query)
        {
            return query
                .Select(a => new ArticleResult
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    Content = a.Content,
                    PublishedDate = a.PublishedDate,
                    AuthorId = a.AuthorId,
                    AuthorName = a.Author != null ? a.Author.FirstName + " " + a.Author.LastName : null
                });
        }

        public static IQueryable<PersonResult> Project(this IQueryable<Person> query)
        {
            return query.Select(p => new PersonResult
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Email = p.Email,
                Articles = p.Articles.Select(a => new ArticleResult
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    Content = a.Content,
                    PublishedDate = a.PublishedDate,
                    AuthorId = a.AuthorId,
                    AuthorName = a.Author != null ? $"{a.Author.FirstName} {a.Author.LastName}" : null // Assuming 'Author' is a navigation property to 'Person'
                }).ToList()
            });
        }
    }
}
