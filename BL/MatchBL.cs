using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
using Entity;

namespace BL
{
    public class MatchBL : IMatchBL
    {
        IMatchDL matchdl;
        IRegisterDL registerdl;

        public MatchBL(IMatchDL matchdl, IRegisterDL registerdl)
        {
            this.matchdl = matchdl;
            this.registerdl = registerdl;
        }
        //get
        public async Task<List<Match>> GetMatches()
        {
            return await matchdl.GetMatches();
        }
        //GetMatchByFamilyId
        public async Task<Match> GetMatchByFamilyId(int id)
        {
            return await matchdl.GetMatchByFamilyId(id);
        }

        public async Task<List<Match>> GetMatchByStudentId(int id)
        {
            return await matchdl.GetMatchByStudentId(id);
        }

        //getStudentToMatch
        public async Task<List<Register>> GetStudentToMatch(Family family)
        {
            List<Register> l = await registerdl.GetRegister();
            List<Match> lm = await matchdl.GetMatches();
            List<Register> lr = new List<Register>();
            foreach (Register sr in l)
            {
                if (sr.NeihborhoodId == family.NeighborhoodId
                    && sr.VolunteerTypeId == family.VolunteerTypeId)
                {
                    Match match = lm.Single(m => m.RegisterId == sr.Id);
                    if (match == null)
                    {
                        lr.Add(sr);
                   
                    }
                }
            }

            return lr;
        }

        

        public async Task<int> postMatch(Match match)
        {
            return await matchdl.postMach(match);
        }
        public async Task<Match> putMatch(Match match)
        {
            return await matchdl.putMach(match);
        }
        public async Task DeleteMatch(int id)
        {
            await matchdl.deleteMatch(id);
        }

        public Task deleteMatch(int id)
        {
            throw new NotImplementedException();
        }
    }
}
