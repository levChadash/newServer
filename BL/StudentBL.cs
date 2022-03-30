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
        //getby student id
        public async Task<Student> GetByStudentId(string id)
        {
            return await studentdl.GetByStudentId(id);
        }
        //get student by user id
        public async Task<Student> getStudentByUserId(int id)
        {
            return await studentdl.getStudentByUserId(id);
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
        

        public async Task UploadingAStudentFile()
        {

        }


    }
}
