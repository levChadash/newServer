using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DL;
using Entity;


namespace BL
{
   public class StudentBL : IStudentBL
    {
        IStudentDL studentdl;

        public StudentBL(IStudentDL studentdl)
        {
            this.studentdl = studentdl;
        }
        //get
        public async Task<List<Student>> GetStudents()
        {
            return await studentdl.GetStudents();
        }
        //getById
        public async Task<Student> GetStudentById(int id)
        {
            return await studentdl.GetStudentById(id);
        }
        
        // post

        public async Task<int> PostStudent(Student new_student)
        {
            return await studentdl.PostStudent(new_student);

        }
        //put
        public async Task<Student> PutStudent(Student student)
        {
            return await studentdl.PutStudent(student);

        }
        //delete
        public async Task Deletestudent(int id)
        {
            await studentdl.Deletestudent(id);
        }
        //getById person
        public async Task<Person> GetPersonById(int id)
        {
           return await studentdl.GetPersonById(id);
        }
        //getPersonByIdNumber
        public async Task<Person> GetPersonByIdNumber(string idnum)
        {
            return await studentdl.GetPersonByIdNumber(idnum);
        }
        public async Task<int> PostPerson(Person new_person)
        {
            return await studentdl.PostPerson(new_person);
        }
        public async Task DeletePersont(int id)
        {
            await studentdl.DeletePerson(id);
        }
        public async Task<StudentYear> GetStudentYearstById(int id)
        {
            return await studentdl.GetStudentYearstById(id);
        }
        public async Task<int> PostStudentYears(StudentYear new_studentYear)
        {
            return await studentdl.PostStudentYears(new_studentYear);
        }
        public async Task DeleteStudentYears(int id)
        {
            await studentdl.DeleteStudentYears(id);
        }
        public async Task Delete()
        {
            List<Student> ls = await studentdl.getStudenByYear((int)new DateTime().Year);
            foreach (var student in ls)
            {
                studentdl.DeletePerson(student.Person.Id);
                foreach (var studYear in student.StudentYears)
                {
                    studentdl.DeleteStudentYears(studYear.Id);
                }
                studentdl.Deletestudent(student.Id);
            }

        }

        public async Task UploadingAStudentFile()
        {

        }


    }
}
