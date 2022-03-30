using Entity;
using System.Threading.Tasks;

namespace DL
{
    public interface IstudentsVolunteeringDL
    {
        Task<StudentsVolunteering> GetByStudentId(int id);
        Task<int> post(StudentsVolunteering studentsVolunteering);
    }
}