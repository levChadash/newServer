using System;
using System.Collections.Generic;
using Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DL
{
   public class StudentDL : IStudentDL
    {
        VolunteerContext vrc;
        public StudentDL(VolunteerContext vrc)
        {
            this.vrc = vrc;
        }
        //get
        public async Task<List<Student>> GetStudents()
        {
            //throw new Exception();
           var studentL = await vrc.Students.Include(s => s.Grade).Include(s => s.User).ToListAsync();
            return studentL;
        }
        //getById
        public async Task<Student> GetStudentById(int id)
        {
            var student = await vrc.Students.Where(s=>s.Id==id).Include(s => s.Grade).Include(s => s.User).FirstOrDefaultAsync();
        
            return student;
        }
        //getStudentByNumberId
        public async Task<Student> GetByStudentId(string idnum)
        {
            return vrc.Students.FirstOrDefault(sid => sid.User.IdNumber == idnum);
        }
        //get student by user id
        public async Task<Student> getStudentByUserId(int id)
        {
            return vrc.Students.FirstOrDefault(sid => sid.User.Id == id);
        }


        //post
        public async Task<int> PostStudent(Student new_student)
        {
            await vrc.Students.AddAsync(new_student);
            return await vrc.SaveChangesAsync();
        }
        //put
        public async Task<Student> PutStudent(Student student)
        {
            Student studentToUpDate = await vrc.Students.Where(s => s.Id == student.Id).Include(s => s.Grade).FirstOrDefaultAsync(); ;
            if (studentToUpDate == null)
            {
                return null;
            }
            vrc.Entry(studentToUpDate).CurrentValues.SetValues(student);

            await vrc.SaveChangesAsync();
            return student;
        }
        //delete
        public async Task Deletestudent(int id)
        {
            Student student = await vrc.Students.FindAsync(id);
            if (student == null)
                throw new Exception();
            vrc.Students.Remove(student);
            await vrc.SaveChangesAsync();
        }
       


    }
}
