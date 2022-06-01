using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IstudentsVolunteeringBL
    {
        Task<StudentsVolunteering> GetByStudentId(int id);
        Task<int> post(StudentsVolunteering studentsVolunteering);
        Task delete(int id);
        Task<List<StudentsVolunteering>> Get();
        Task<List<StudentsVolunteering>> GetByVolunteeringId(int volunteeringId);
    }
}