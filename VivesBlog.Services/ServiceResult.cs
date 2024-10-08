using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VivesBlog.Services
{
    // Generic version of ServiceResult for when we return data (e.g., PersonResult)
    public class ServiceResult<T> : ServiceResult
    {
        public T? Data { get; set; }

        public ServiceResult()
        {
        }

       /* public ServiceResult(T data)
        {
            Data = data;
            IsSuccess = true;
        }*/
    }

    // Base version of ServiceResult for handling basic operations without data
    public class ServiceResult
    {
        // Flag to check if the operation was successful
        public bool IsSuccess { get; private set; } = true;

        // List of error messages (validation errors, not found errors, etc.)
        public List<string> Errors { get; private set; } = new List<string>();

        // Add an error to the result
        public void AddError(string errorMessage)
        {
            IsSuccess = false;  // Mark the result as unsuccessful
            Errors.Add(errorMessage);
        }

        // Helper method for 'Not Found' errors (e.g., when an entity is not found by ID)
        public void NotFound(string entityName, object id)
        {
            AddError($"{entityName} with id {id} not found.");
        }

        // Helper method for marking an entity as 'Deleted'
        public void Deleted(string entityName)
        {
            AddError($"{entityName} has been deleted.");
        }

        // Custom validation method (can be expanded as needed)
        public void Validate(object entity)
        {
            // Perform validation logic (such as using DataAnnotations)
            // For simplicity, let's just demonstrate a simple validation rule
            if (entity is null)
            {
                AddError("Entity is null.");
            }
        }
    }
}
