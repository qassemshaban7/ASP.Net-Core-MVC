using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models
{
    public class Student
    {
        public int Id { get; set; }
       // [DataType(DataType.EmailAddress)]
        [Display(Name="Student Name")]
        [Required]
        [MaxLength(30,ErrorMessage ="Name must be less than 30 letter")]
        [MinLength(3,ErrorMessage ="NAme must be greater than 2 letter")]
        [UniqueName(msg ="hiiiii")]
       
        [Remote(action:"CheckName",controller:"Student"
            ,AdditionalFields = "Address"
            , ErrorMessage ="Name Must Contai ITI")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"(Alex|Assiut)",ErrorMessage ="Address Must be Alex or Assiut")]
        public string Address { get; set; }
        
        [Display(Name="Student Age")]
        [Required]
        [Range(maximum:50,minimum:20)]
        public int Age { get; set; }
        
        [Required]
        [RegularExpression(@"\w+\.(jpg|png)",ErrorMessage ="Image must be jpg or png")]
        public string Image { get; set; }
        
        [ForeignKey("Department")]
        [Display(Name="DEpartment Name")]
        public int Dept_Id { get; set; }

        public virtual Department? Department { get; set; }// = new Department();
    }
}
