using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IVolunteerTypeBL
    {
        Task<List<VolunteerType>> getVolunteerTypes();
    }
}