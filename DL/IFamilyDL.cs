using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
     public interface IFamilyDL
    {
        Task<List<Family>> GetFamilies();
        Task<Family> GetFamilyById(int id);
        Task<Family> PutFamily(Family family);
        Task<int> PostFamily(Family new_family);
        Task DeleteFamily(int id);
    }
}