using static CRUD_Operations.Models.Student;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRUD_Operations.Models
{
    public class Department
    {

               [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "*")]
        public int DeptId { get; set; }
        [Required(ErrorMessage = "*")]
        [StringLength(15, MinimumLength = 2)]

        public string DeptName { get; set; }
        [Range(1, 3000)]
        public int Capacity { get; set; }

        public bool status { get; set; } = true;
        
               public virtual List<Student> Students { get; set; }
    }
}
