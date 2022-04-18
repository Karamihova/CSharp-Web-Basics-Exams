namespace Git.Controllers
{
    using Git.Data;
    using Git.Data.Models;
    using Git.Models.Commit;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Linq;
    using static Data.DataConstants;

    public class CommitsController : Controller
    {
        private readonly ApplicationDbContext data;

        public CommitsController(ApplicationDbContext data)
        {
            this.data = data;
        }

        [Authorize]
        public HttpResponse All()
        {
            var commits = this.data
                .Commits
                .Where(c => c.CreatorId == this.User.Id)
                .Select(c => new CommitListingViewModel
                {
                    Id = c.Id,
                    Repository = c.Repository.Name,
                    Description = c.Description,
                    CreatedOn = c.CreatedOn.ToLocalTime().ToString("R"),
                })
                .ToList();

            return this.View(commits);
        }

        [Authorize]
        public HttpResponse Create(string id)
        {
            var repository = this.data
                .Repositories
                .Where(r => r.Id == id)
                .Select(r => new CommitToRepositoryViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                })
                .FirstOrDefault();

            if (repository == null)
            {
                return this.BadRequest();
            }

            return this.View(repository);
        }

        [HttpPost]
        [Authorize]
        public HttpResponse Create(CreateCommitFormModel model)
        {
            if (!this.data.Repositories.Any(r => r.Id == model.Id))
            {
                return this.NotFound();
            }

            if (model.Description.Length < DescriptionMinLength)
            {
                return this.Error($"Description must be at  least {DescriptionMinLength} characters long.");
            }

            var commit = new Commit
            {
                Description = model.Description,
                RepositoryId = model.Id,
                CreatorId = this.User.Id
            };

            this.data.Commits.Add(commit);
            this.data.SaveChanges();

            return this.Redirect("/Repositories/All");
        }

        [Authorize]
        public HttpResponse Delete(string id)
        {
            var commit = this.data.Commits.Find(id);
            if (commit == null || commit.CreatorId != this.User.Id)
            {
                return this.BadRequest();
            }

            this.data.Commits.Remove(commit);
            this.data.SaveChanges();

            return this.Redirect("/Commits/All");
        }
    }
}
