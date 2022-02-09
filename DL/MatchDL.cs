using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class MatchDL : IMatchDL
    {
        VolunteerContext vrc;
        public MatchDL(VolunteerContext vrc)
        {
            this.vrc = vrc;
        }
        //get
        public async Task<List<Match>> GetMatches()
        {
            List<Match> MatchL = await vrc.Matches.ToListAsync();
            return MatchL;
        }
        //getMatchByFamilyId
        public async Task<Match> GetMatchByFamilyId(int id)
        {
            return vrc.Matches.Single(sc => sc.Family.Id == id);
        }
        //getMatchBystudentId
        public async Task<List<Match>> GetMatchByStudentId(int id)
        {
            return vrc.Matches.Where(sc => sc.Register.Student.Id == id).ToList();
        }
        
        public async Task<int> postMach(Match match)
        {
            await vrc.Matches.AddAsync(match);
            await vrc.SaveChangesAsync();
            return match.Id;
        }
        public async Task<Match> putMach(Match match)
        {
            Match matchToUpdate = await vrc.Matches.FindAsync(match.Id);
            if (matchToUpdate == null)
                return null;
            vrc.Entry(matchToUpdate).CurrentValues.SetValues(match);
            await vrc.SaveChangesAsync();
            return match;
        }
        public async Task deleteMatch(int id)
        {
            object match = vrc.Matches.FindAsync(id);
            if (match == null)
                throw new Exception();
            vrc.Matches.Remove((Match)(match));
            await vrc.SaveChangesAsync();
        }




    }
}
