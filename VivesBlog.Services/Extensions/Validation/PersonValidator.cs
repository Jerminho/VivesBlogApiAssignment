using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivesBlog.Dto.Requests;
using VivesBlog.Dto.Results;

namespace VivesBlog.Services.Extensions.Validation
{
    public static class PersonValidator
    {
        public static void Validate(this ServiceResult<PersonResult> serviceResult, PersonRequest request)
        {
            // Validate First Name
            if (string.IsNullOrWhiteSpace(request.FirstName))
            {
                serviceResult.NotEmpty(nameof(request.FirstName));
            }

            // Validate Last Name
            if (string.IsNullOrWhiteSpace(request.LastName))
            {
                serviceResult.NotEmpty(nameof(request.LastName));
            }

            // Optional: Validate Email
            if (!string.IsNullOrWhiteSpace(request.Email) && !new EmailAddressAttribute().IsValid(request.Email))
            {
                serviceResult.Invalid(nameof(request.Email), "Invalid email format.");
            }
        }
    }
}
