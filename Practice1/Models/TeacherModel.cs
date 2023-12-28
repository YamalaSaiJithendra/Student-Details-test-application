using System.ComponentModel.DataAnnotations;

namespace Practice1.Models
{
    public class TeacherModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Teacher_Name is Required.")]
        public string Teacher_Name { get; set; }
        [Required(ErrorMessage = "EmpId is Required.")]
        public int EmpId { get; set; }
        [Required(ErrorMessage = "TeachingSubject is Required.")]
        public string TeachingSubject { get; set; }
        [Required(ErrorMessage = "Experience is Required.")]
        public int Experience { get; set; }
        [Required(ErrorMessage = "Phone_Number is Required.")]
        public string Phone_Number { get; set; }
    }
}
