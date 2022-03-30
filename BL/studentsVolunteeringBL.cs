using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;

namespace BL
{
    public class studentsVolunteeringBL : IstudentsVolunteeringBL
    {
        IstudentsVolunteeringDL studentsvolunteeringdl;
        public studentsVolunteeringBL(IstudentsVolunteeringDL studentsvolunteeringdl)
        {
            this.studentsvolunteeringdl = studentsvolunteeringdl;
        }
        public async Task<StudentsVolunteering> GetByStudentId(int id)
        {
            return await studentsvolunteeringdl.GetByStudentId(id);
        }
        public async Task<int> post(StudentsVolunteering studentsVolunteering)
        {
            return await studentsvolunteeringdl.post(studentsVolunteering);
        }
    }
}
