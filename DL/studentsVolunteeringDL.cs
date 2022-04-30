using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class studentsVolunteeringDL : IstudentsVolunteeringDL
    {
        VolunteerContext vrc;
        public studentsVolunteeringDL(VolunteerContext vrc)
        {
            this.vrc = vrc;
        }
        public async Task<StudentsVolunteering> GetByStudentId(int id)
        {
            return await vrc.StudentsVolunteerings.Where(x => x.StudentId == id).FirstOrDefaultAsync();
        }
        public async Task<int> post(StudentsVolunteering studentsVolunteering)
        {
            await vrc.StudentsVolunteerings.AddAsync(studentsVolunteering);
            await vrc.SaveChangesAsync();
            return studentsVolunteering.Id;
        }
        public async Task delete(int id)
        {
            StudentsVolunteering st = await vrc.StudentsVolunteerings.FindAsync(id);
            if (st == null)
                throw new Exception();
            vrc.StudentsVolunteerings.Remove(st);
            await vrc.SaveChangesAsync();
        }
        public async Task deleteByVolunteeringId(int id)
        {
            List<StudentsVolunteering> st = await vrc.StudentsVolunteerings.Where(sv=>sv.VolunteeringId==id).ToListAsync();
            if (st == null)
                throw new Exception();
            foreach(StudentsVolunteering studentv in st)
            {
                vrc.StudentsVolunteerings.Remove(studentv);

            }
            await vrc.SaveChangesAsync();
        }
    }
}
