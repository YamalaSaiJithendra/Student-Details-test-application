using Practice1.Models;

namespace Practice1.Repository.Interfaces
{
    public interface ITeacherRepository
    {
        bool AddTeacherDetails(TeacherModel tcr);
        List<TeacherModel> GetAllTeachers();
        bool UpdatedTeacher(TeacherModel tcr);
        bool DeleteTeacher(int id);

    }
}
