using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class GradeDL : IGradeDL
    {
        VolunteerContext vrc;
        public GradeDL(VolunteerContext vrc)
        {
            this.vrc = vrc;
        }

        //getBynum
        public async Task<int> GetGradeId(int num)
        {
            Grade grade = await vrc.Grades.Where(s => s.GradeNum == num).FirstOrDefaultAsync();
            return grade.Id;
        }
    }
}
