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
           var studentL = await vrc.Students.Include(s => s.Grade).Include(s=> s.Neighborhood).Include(s => s.Person).ToListAsync();
            return studentL;
        }
        //getById
        public async Task<Student> GetStudentById(int id)
        {
            var student = await vrc.Students.Where(s=>s.Id==id).Include(s => s.Grade).Include(s => s.Neighborhood).Include(s => s.Person).FirstOrDefaultAsync();
        
            return student;
        }
        //getStudentByNumberId
        public async Task<Student> GetStudentByNumberId(string idnum)
        {
            return vrc.Students.FirstOrDefault(sid => sid.Person.IdNumber == idnum);
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
            Student studentToUpDate = await vrc.Students.Where(s => s.Id == student.Id).Include(s => s.Grade).Include(s => s.Neighborhood).Include(s => s.Person).FirstOrDefaultAsync(); ;
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
        //get person
        public async Task<Person> GetPersonById(int id)
        {
            Person person = await vrc.People.FindAsync(id);
            return person;
        }
        //getPersonByNumberId
        public async Task<Person> GetPersonByIdNumber(string idnum)
        {
            return vrc.People.Single(sid => sid.IdNumber == idnum);
        }
        //post person
        public async Task<int> PostPerson(Person new_person)
        {
            await vrc.People.AddAsync(new_person);
            return await vrc.SaveChangesAsync();
        }
        //delete person
        public async Task DeletePerson(int id)
        {
            Person person = await vrc.People.FindAsync(id);
            if (person == null)
                throw new Exception();
            vrc.People.Remove(person);
            await vrc.SaveChangesAsync();
        }
        //get StudentYears
        public async Task<StudentYear> GetStudentYearstById(int id)
        {
            StudentYear studentYear = await vrc.StudentYears.FindAsync(id);
            return studentYear;
        }
        //post StudentYears
        public async Task<int> PostStudentYears(StudentYear new_studentYear)
        {
            await vrc.StudentYears.AddAsync(new_studentYear);
            return await vrc.SaveChangesAsync();
        }
        //delete StudentYears
        public async Task DeleteStudentYears(int id)
        {
            StudentYear studentYears = await vrc.StudentYears.FindAsync(id);
            if (studentYears == null)
                throw new Exception();
            vrc.StudentYears.Remove(studentYears);
            await vrc.SaveChangesAsync();
        }
        //getStudentByYear
        public async Task<List<Student>> getStudenByYear(int year)
        {
            return vrc.Students.Where(sc => sc.Grade.StartYear <= year-7).ToList();
        }


    }
}
