using Microsoft.EntityFrameworkCore;
using VivesBlog.Core;
using VivesBlog.Dto.Results;
using VivesBlog.Model;
using System.Linq;
using VivesBlog.Services.Extensions.Projection;
using VivesBlog.Dto.Requests;

namespace VivesBlog.Services
{
    public class PersonService
    {
        private readonly VivesBlogDbContext _dbContext;

        public PersonService(VivesBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Find
        public async Task< IList<PersonResult>> Find()
        {
            return await _dbContext.People
                .Project()
                .ToListAsync();
        }

        //Get (by id)
        public async Task<ServiceResult<PersonResult>> Get(int id)
        {
            var serviceResult = new ServiceResult<PersonResult>();

            var person = await _dbContext.People
                .Project()
                .FirstOrDefaultAsync(p => p.Id == id);

            serviceResult.Data = person;
            if (person is null)
            {
                serviceResult.NotFound(nameof(Person), id);
            }

            return serviceResult;
        }

        // SO FAR SO GOOD

        //Create
        public async Task<ServiceResult<PersonResult>> Create(PersonRequest request)
        {
            var serviceResult = new ServiceResult<PersonResult>();

            // Validate the request DTO
            serviceResult.Validate(request);
            if (!serviceResult.IsSuccess)
            {
                return serviceResult;
            }

            var person = new Person
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
            };

            _dbContext.People.Add(person);
            await _dbContext.SaveChangesAsync();

            return await Get(person.Id);
        }

        //Update
        public async Task<ServiceResult<PersonResult>> Update(int id, PersonRequest request)
        {
            var serviceResult = new ServiceResult<PersonResult>();

            // Retrieve the person from the database
            var person = await _dbContext.People
                .FirstOrDefaultAsync(p => p.Id == id);

            if (person is null)
            {
                serviceResult.NotFound(nameof(Person), id);
                return serviceResult;
            }

            person.FirstName = request.FirstName;
            person.LastName = request.LastName;
            person.Email = request.Email;

            await _dbContext.SaveChangesAsync();

            return await Get(id);
        }

        //Delete
        public async Task<ServiceResult> Delete(int id)
        {
            var serviceResult = new ServiceResult();

            // Find the person by ID
            var person = await _dbContext.People
                .FirstOrDefaultAsync(p => p.Id == id);

            if (person is null)
            {
                serviceResult.NotFound(nameof(Person), id);
                return serviceResult;
            }

            _dbContext.People.Remove(person);
            await _dbContext.SaveChangesAsync();

            serviceResult.Deleted(nameof(Person));
            return serviceResult;
        }

    }
}
