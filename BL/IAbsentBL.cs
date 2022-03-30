using Entity;
using System.Threading.Tasks;

namespace BL
{
    public interface IAbsentBL
    {
        Task<int> postAbsent(Absent abs);
    }
}