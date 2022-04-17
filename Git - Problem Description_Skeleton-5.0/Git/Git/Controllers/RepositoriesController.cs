namespace Git.Controllers
{
    using Git.Data;
    using Git.Data.Models;
    using Git.Models.Repository;
    using Git.Services;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Linq;
    using static Data.DataConstants;

    public class RepositoriesController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IValidator validator;

        public RepositoriesController(ApplicationDbContext data, IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        public HttpResponse All()
        {
            var repositories = this.data
                .Repositories
                .Where(r => r.IsPublic)
                .Select(r => new RepositoryListingViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Commits = r.Commits.Count(),
                    Owner = r.Owner.Username,
                    CreatedOn = r.CreatedOn.ToString("R"),
                })
                .ToList();

            return this.View(repositories);
        }

        public HttpResponse Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public HttpResponse Create(CreateRepositoryFormModel model)
        {
            var modelErrors = this.validator.ValidateRepository(model);

            if (modelErrors.Any())
            {
                return this.Error(modelErrors);
            }

            var repository = new Repository
            {
                Name = model.Name,
                IsPublic = model.RepositoryType == RepositoryPublic,
                OwnerId = this.User.Id // if we want this, means that we must have a authorize attribute!!!!!
            };

            this.data.Repositories.Add(repository);
            this.data.SaveChanges();

            return this.Redirect("/Repositories/All");
        }
    }
}
