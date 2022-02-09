using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IStudentDL
    {
        Task Deletestudent(int id);
        Task<Student> GetStudentById(int id);
        Task<Student> GetStudentByNumberId(string idnum);
        
        Task<List<Student>> GetStudents();
        Task<int> PostStudent(Student new_student);
        Task<Student> PutStudent(Student student);
       
        Task<Person> GetPersonById(int id);
        Task<Person> GetPersonByIdNumber(string idnum);
        Task<int> PostPerson(Person new_person);
        Task DeletePerson(int id);
        Task<StudentYear> GetStudentYearstById(int id);
        Task<int> PostStudentYears(StudentYear new_studentYear);
        Task DeleteStudentYears(int id);
        Task<List<Student>> getStudenByYear(int year);
    }
}