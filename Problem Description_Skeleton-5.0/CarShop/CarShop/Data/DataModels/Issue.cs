namespace CarShop.Data.DataModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;
    public class Issue
    {
        [Key]
        [Required]
        [StringLength(IdMaxValue)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Description { get; set; }

        public bool IsFixed { get; set; }

        [Required]
        public string CarId { get; set; }

        public Car Car { get; set; }
    }
}
