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
        Task<Person> GetPersonByIdNumber(string idnum);
        Task<Person> GetPersonById(int id);
        Task<int> PostPerson(Person new_person);
        Task DeletePersont(int id);
        Task<StudentYear> GetStudentYearstById(int id);
        Task<int> PostStudentYears(StudentYear new_studentYear);
        Task DeleteStudentYears(int id);
        Task Delete();
    }
}