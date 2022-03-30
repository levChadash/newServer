using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IStudentDL
    {
        Task Deletestudent(int id);
        Task<Student> GetStudentById(int id);
        Task<Student> GetByStudentId(string idnum);
        
        Task<List<Student>> GetStudents();
        Task<int> PostStudent(Student new_student);
        Task<Student> PutStudent(Student student);
        Task<Student> getStudentByUserId(int id);


    }
}