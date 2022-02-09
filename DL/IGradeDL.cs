using System.Threading.Tasks;

namespace DL
{
     public interface IGradeDL
    {
        Task<int> GetGradeId(int num);
    }
}