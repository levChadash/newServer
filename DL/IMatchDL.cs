using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IMatchDL
    {
        Task<Match> GetMatchByFamilyId(int id);
        Task<List<Match>> GetMatchByStudentId(int id);
        Task<List<Match>> GetMatches();
        Task<int> postMach(Match match);
        Task<Match> putMach(Match match);
        Task deleteMatch(int id);
    }
}