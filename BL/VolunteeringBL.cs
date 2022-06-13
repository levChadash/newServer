using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DL;
using DTO;
using Entity;

using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Directions.Request;
using GoogleApi.Entities.Maps.Directions.Response;
using GoogleApi.Entities.Maps.Geocoding.PlusCode.Request;
using GoogleApi.Entities.Maps.Common;
using System.Linq;
using AutoMapper;

namespace BL
{
    public class VolunteeringBL : IVolunteeringBL
    {
        IVolunteeringDL volunteeringdl;
        IstudentsVolunteeringDL volunteeringstudentsdl;
        IMapper mapper;
        public VolunteeringBL(IVolunteeringDL volunteeringdl, IstudentsVolunteeringDL volunteeringstudentsdl, IMapper mapper)
        {
            this.volunteeringdl = volunteeringdl;
            this.volunteeringstudentsdl = volunteeringstudentsdl;
            this.mapper = mapper;
        }

        //get
        public async Task<List<Volunteering>> Get()
        {
            return await volunteeringdl.Get();
        }
        //getbyid
        public async Task<Volunteering> GetById(int id)
        {
            Volunteering v = await volunteeringdl.GetById(id);
            return v;
        }

        //get not set
        public async Task<List<Volunteering>> GetNotSet()
        {
            return await volunteeringdl.GetNotSet();
        }


        //getbyfamilyid
        //public async Task<List<Volunteering>> GetVolunteeringByFamilyId(int id)
        //{
        //    return await volunteeringdl.GetVolunteeringByFamilyId(id);
        //}


        //post
        public async Task<int> post(Volunteering rg)
        {
            return await volunteeringdl.post(rg);

        }
        //put
        public async Task<Volunteering> put(Volunteering rg)
        {
            return await volunteeringdl.put(rg);
        }

        public async Task<List<StudentVolunteeringDTO>> PutFamily( FamilyDTO family)
        {
            string origion = family.Neighborhood;
            Address aOrigion = new Address(origion);
            LocationEx origionlx = new LocationEx(aOrigion);
            string destination;
            Address aDestination;
            LocationEx destinationlx;
            DirectionsRequest request = new DirectionsRequest();

            request.Key = "AIzaSyBHO2BM3GPRMdYEajDEy9hph9GESt8bXrA";
            request.Origin = origionlx;

            int min=int.MaxValue;
            Volunteering minVolunteering=null;
            List<Volunteering> lv = await GetNotSet();
            foreach(var volunteering in lv)
            {
                if (volunteering.VolunteerTypeId == family.VolunteerTypeId)
                {

                    destination = volunteering.Neighborhood;
                    aDestination = new Address(destination);
                    destinationlx = new LocationEx(aDestination);
                    request.Destination = destinationlx;
                    var response = GoogleApi.GoogleMaps.Directions.Query(request);
                    int d= response.Routes.FirstOrDefault().Legs.First().Distance.Value;

                    if(d < min)
                    {
                        min = d;
                        minVolunteering = volunteering;
                    }
                }
            }

            List<StudentsVolunteering> lsv =await volunteeringstudentsdl.GetByVolunteeringId(minVolunteering.Id);
            List<StudentVolunteeringDTO> lsvd = mapper.Map<List<StudentsVolunteering>, List<StudentVolunteeringDTO>>(lsv);
           
            
            return lsvd;
            
        }
        //delete
        public async Task delete(int id)
        {
            await volunteeringstudentsdl.deleteByVolunteeringId(id);
            await volunteeringdl.delete(id);
        }

    }
}
