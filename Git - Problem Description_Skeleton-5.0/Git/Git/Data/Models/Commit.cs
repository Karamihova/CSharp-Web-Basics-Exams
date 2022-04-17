namespace Git.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;
    public class Commit
    {
        [Key]
        [Required]
        [StringLength(IdMaxLength)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        [Required]
        public string CreatorId { get; set; }

        public User Creator { get; set; }

        [Required]
        public string RepositoryId { get; set; }

        public Repository Repository { get; set; }
        
    }
}
