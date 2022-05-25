using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IVolunteeringDL
    {
        Task delete(int id);
        Task<List<Volunteering>> Get();
        Task<List<Volunteering>> GetNotSet();
       // Task<Volunteering> GetVolunteeringByFamilyId(int id);
        Task<int> post(Volunteering rg);
        Task<Volunteering> put(Volunteering rg);
        Task<Volunteering> getById(int id);
        Task<List<Volunteering>> getByFamilyId(int id);
    }
}