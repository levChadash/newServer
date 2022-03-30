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
    }
}
