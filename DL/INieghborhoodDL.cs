using System.Threading.Tasks;

namespace DL
{
    public interface INieghborhoodDL
    {
        Task<int> GetNieghborhoodId(string name);
    }
}