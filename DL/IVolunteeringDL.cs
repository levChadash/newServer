using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IVolunteeringDL
    {
        Task deleteRegister(int id);
        Task<List<Volunteering>> GetRegister();
       // Task<Volunteering> GetVolunteeringByFamilyId(int id);
        Task<int> postRegister(Volunteering rg);
        Task<Volunteering> putRegister(Volunteering rg);
        Task<Volunteering> getRegisterById(int id);
    }
}