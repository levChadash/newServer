using Entity;
using System.Threading.Tasks;

namespace BL
{
    public interface IstudentsVolunteeringBL
    {
        Task<StudentsVolunteering> GetByStudentId(int id);
        Task<int> post(StudentsVolunteering studentsVolunteering);
        Task delete(int id);
    }
}