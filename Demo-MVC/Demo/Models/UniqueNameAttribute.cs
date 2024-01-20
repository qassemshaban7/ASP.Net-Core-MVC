using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class UniqueNameAttribute:ValidationAttribute
    {
        public string msg { get; set; }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return null;
            string newName= value.ToString();
            ITIEntity context = new ITIEntity();
            Student stddb=  context.Students.FirstOrDefault(s=>s.Name==newName);
            //Student stdForm = (Student)validationContext.ObjectInstance;
            if (stddb != null)
            {
                return new ValidationResult("Name Must Be Unique");
            }
            return ValidationResult.Success;
        }
    }
}
