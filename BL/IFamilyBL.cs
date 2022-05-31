using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IFamilyBL
    {
        Task<List<Family>> GetFamilies();
        Task<Family> GetFamilyById(int id);
        Task<List<Family>> GetNotSetFamilies();
        Task<int> PostFamily(Family new_family);
        Task<Family> PutFamily(Family family);
        Task DeleteFamily(int id);
    }
}