using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IVolunteeringBL
    {
        Task delete(int id);
        Task<List<Volunteering>> Get();
        Task<int> post(Volunteering rg);
        Task<Volunteering> put(Volunteering rg);
    }
}