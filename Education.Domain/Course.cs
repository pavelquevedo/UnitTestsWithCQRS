using Education.Domain.Validation;
using System.ComponentModel.DataAnnotations;

namespace Education.Domain
{
    public class Course
    {
        [Key]
        public Guid CourseId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(200)]
        public string Description { get; set; }
        [DataType(DataType.Date)]
        [DateInFuture]
        public DateTime? PublishDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? CreationDate { get; set; }
        public decimal Price { get; set; }
    }
}