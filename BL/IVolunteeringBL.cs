using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IVolunteeringBL
    {
        Task deleteRegister(int id);
        Task<List<Volunteering>> GetRegister();
        Task<int> postRegister(Volunteering rg);
        Task<Volunteering> putRegister(Volunteering rg);
    }
}