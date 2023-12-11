using System.ComponentModel.DataAnnotations;

namespace Practice1.Models
{
    public class StudentModel
    {
        [Display(Name = "ID")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Name is Required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        public int Age { get; set; }
        public bool Gender { get; set; }

        [Required(ErrorMessage = "City Name required.")]
        public string City { get; set; }
    }
    public class TeacherModel
    {
        public string Teacher_Name { get; set; }
        public int EmpId { get; set; }
        public string TeachingSubject { get; set; }
        public int Experience { get; set; }
        public int Phone_Number { get; set; }
        public string? Address { get; set; }
    }
}
