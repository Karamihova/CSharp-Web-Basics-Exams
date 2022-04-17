namespace Git.Services
{
    using Git.Models.Repository;
    using Git.Models.Users;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using static Git.Data.DataConstants;
    public class Validator : IValidator
    {
        public ICollection<string> ValidateRepository(CreateRepositoryFormModel model)
        {
            var errors = new List<string>();

            if (model.Name.Length < RepositoryMinName || model.Name.Length > RepositoryMaxName)
            {
                errors.Add($"Username '{model.Name}' is not valid. It must be between {RepositoryMinName} and {RepositoryMaxName} characters long.");
            }

            if (model.RepositoryType != RepositoryPrivate && model.RepositoryType != RepositoryPublic)
            {
                errors.Add($"Repository must be either a {RepositoryPublic} or {RepositoryPrivate} type");
            }

            return errors;
        }

        public ICollection<string> ValidateUser(RegisterUserFormModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < UserMinName || model.Username.Length > UserMaxName)
            {
                errors.Add($"Username '{model.Username}' is not valid. It must be between {UserMinName} and {UserMaxName} characters long.");
            }

            if (!Regex.IsMatch(model.Email, UserEmailRegularExpression))
            {
                errors.Add($"Email {model.Email} is not a valid e-mail address.");
            }

            if (model.Password.Length < UserMinPassword || model.Password.Length > UserMaxPassword)
            {
                errors.Add($"The provided password is not valid. It must be between {UserMinPassword} and {UserMaxPassword} characters long.");
            }

            if (model.Password.Any(x => x == ' '))
            {
                errors.Add($"The provided password cannot contain whitespaces.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add($"Password and its confirmation are different.");
            }

            return errors;
        }
    }
}
