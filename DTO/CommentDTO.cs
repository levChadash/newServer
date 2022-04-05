using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
     public class CommentDTO
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string FromUserName { get; set; }
        public string ToUserName { get; set; }
        public string Comment1 { get; set; }
        public string NeighborhoodName { get; set; }
        public string VolunteerType { get; set; }


    }
}
