using Entity;
using System.Threading.Tasks;

namespace DL
{
    public interface IstudentsVolunteeringDL
    {
        Task<StudentsVolunteering> GetByStudentId(int id);
        Task<int> post(StudentsVolunteering studentsVolunteering);
        Task delete(int id);
        Task deleteByVolunteeringId(int id);

    }
}