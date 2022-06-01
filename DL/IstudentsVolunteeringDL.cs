using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IstudentsVolunteeringDL
    {
        Task<StudentsVolunteering> GetByStudentId(int id);
        Task<List<StudentsVolunteering>> Get();
        Task<List<StudentsVolunteering>> GetByVolunteeringId(int volunteeringId);
        Task<int> post(StudentsVolunteering studentsVolunteering);
        Task delete(int id);
        Task deleteByVolunteeringId(int id);

    }
}