using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_Operations.Models
{
    public class Student
    {

        public int Id { get; set; }

         [Required(ErrorMessage ="*")]
        [StringLength(15,MinimumLength =3)]
        public string Name { get; set; }
        [Range(10,20)]

         public int Age { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Z0-9_]+@[a-zA-Z]+.[a-zA-Z]{2,4}")]
        [Remote(action: "VerifyEmail", controller: "Student", ErrorMessage = "The email address is already in use")]
        public string Email { get; set; }

         [ForeignKey("Department")]

         public int DeptNo { get; set; }
        public bool status { get; set; } = true;

        public virtual Department Department { get; set; }
        
    }
}
