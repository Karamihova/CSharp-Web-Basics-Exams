namespace Git.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;
    public class Repository
    {
        [Key]
        [Required]
        [StringLength(IdMaxLength)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(RepositoryMaxName)]
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public bool IsPublic { get; set; }

        [Required]
        public string OwnerId { get; set; }

        public User Owner { get; set; }

        public ICollection<Commit> Commits { get; set; } = new HashSet<Commit>();
        
    }
}
