using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface ISpecialProjectBL
    {
        Task<List<SpecialProject>> GetPesachProject();
        Task<SpecialProject> getPesachProjectById(int id);
        Task<int> postPesachProject(SpecialProject psp);
        Task<SpecialProject> putPesachProject(SpecialProject psp);
        Task deletePesachProject(int id);

    }
}