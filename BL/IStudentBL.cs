using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IStudentBL
    {
        Task Deletestudent(int id);
        Task<Student> GetStudentById(int id);
        Task<List<Student>> GetStudents();
        Task<int> PostStudent(Student new_student);
        Task<Student> PutStudent(Student student);
        Task<Student> GetByStudentId(string id);
        Task<Student> getStudentByUserId(int id);
    }
}