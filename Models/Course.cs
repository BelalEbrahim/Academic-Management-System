using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_Operations.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50, MinimumLength = 2)]
        public string CourseName { get; set; }

        [Range(1, 100, ErrorMessage = "Duration must be between 1 and 100 hours")]
        public int DurationInHours { get; set; }
    }
}
