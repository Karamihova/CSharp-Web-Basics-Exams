namespace CarShop.Data.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;
    public class Car
    {
        [Key]
        [Required]
        [StringLength(IdMaxValue)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(DefaultMaxLength)]
        public string Model { get; set; }

        [Required]
        public ushort Year { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        [Required]
        [StringLength(CarPlateNumberLength)]
        public string PlateNumber { get; set; }

        [Required]
        public string OwnerId { get; set; }

        public User Owner { get; set; }

        public ICollection<Issue> Issues { get; set; } = new HashSet<Issue>();
    }
}
