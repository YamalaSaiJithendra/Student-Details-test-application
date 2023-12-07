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
}
