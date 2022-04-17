namespace Git.Services
{
    using Git.Models.Repository;
    using Git.Models.Users;
    using System.Collections.Generic;

    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);
        ICollection<string> ValidateRepository(CreateRepositoryFormModel model);
    }
}
