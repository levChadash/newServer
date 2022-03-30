using Entity;
using System.Threading.Tasks;

namespace DL
{
    public interface IAbsentDL
    {
        Task<int> postAbsent(Absent abs);
    }
}