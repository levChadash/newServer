using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
using Entity;

namespace BL
{
    public class VolunteerTypeBL : IVolunteerTypeBL
    {
        IVolunteerTypeDL volunteertypedl;
        public VolunteerTypeBL(IVolunteerTypeDL volunteertypedl)
        {
            this.volunteertypedl = volunteertypedl;
        }
        //get
        public async Task<List<VolunteerType>> getVolunteerTypes()
        {
            return await volunteertypedl.getVolunteerTypes();
        }
    }
}
