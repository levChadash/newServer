using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IAbsentDL
    {
        Task<int> postAbsent(Absent abs);
         Task<List<Absent>> Get();
    }
}