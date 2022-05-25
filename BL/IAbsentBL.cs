using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IAbsentBL
    {
        Task<int> postAbsent(Absent abs);
        Task<List<Absent>> Get();

    }
}