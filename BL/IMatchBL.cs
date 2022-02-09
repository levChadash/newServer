using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IMatchBL
    {
        Task<List<Match>> GetMatches();
        Task<Match> GetMatchByFamilyId(int id);
        Task<List<Match>> GetMatchByStudentId(int id);
        Task<List<Register>> GetStudentToMatch(Family family);
        Task<int> postMatch(Match match);
        Task<Match> putMatch(Match match);
        Task deleteMatch(int id);
           }
}