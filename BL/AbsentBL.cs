using DL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AbsentBL : IAbsentBL
    {
        IAbsentDL absentdl;
        public AbsentBL(IAbsentDL absentdl)
        {
            this.absentdl = absentdl;
        }

        public async Task<List<Absent>> Get()
        {
            return await absentdl.Get();
        }

        public async Task<int> postAbsent(Absent abs)
        {

            return await absentdl.postAbsent(abs);
        }
    }
}
