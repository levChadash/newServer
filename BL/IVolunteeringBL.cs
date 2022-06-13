using DTO;
using Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IVolunteeringBL
    {
        Task delete(int id);
        Task<List<Volunteering>> Get();
        Task<Volunteering> GetById(int id);
        Task<List<Volunteering>> GetNotSet();
        Task<int> post(Volunteering rg);
        Task<Volunteering> put(Volunteering rg);
        Task<List<StudentVolunteeringDTO>> PutFamily(FamilyDTO family);
    }
}