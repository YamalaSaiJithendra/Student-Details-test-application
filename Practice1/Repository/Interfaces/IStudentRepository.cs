using Practice1.Models;

namespace Practice1.Repository.Interfaces
{
    public interface IStudentRepository
    {
        bool AddStudentDetails(StudentModel obj);
        List<StudentModel> GetAllStudents();
        bool UpdateStudent(StudentModel obj);
        bool DeleteStudent(int Id);
    }
}
