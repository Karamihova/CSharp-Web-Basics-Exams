namespace CarShop.Data.DataModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;
    public class User
    {
        [Key]
        [Required]
        [StringLength(IdMaxValue)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(DefaultMaxLength)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public bool IsMechanic { get; set; }
    }
}
