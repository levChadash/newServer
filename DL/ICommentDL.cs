using DTO;
using Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface ICommentDL
    {
        Task<Comment> getCommentById(int id);
        Task<List<Comment>> getComments();
        Task<List<Volunteering>> GetNotSet();
        Task<ActionResult<List<StudentVolunteeringDTO>>> GetByVolunteeringId(int volunteeringId);
        Task<int> postComment(Comment cmt);
        Task<Comment> putComment(Comment cmt);
        Task deleteComment(int id);
       
    }
}