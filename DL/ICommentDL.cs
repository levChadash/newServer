using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface ICommentDL
    {
        Task<Comment> getCommentById(int id);
        Task<List<Comment>> getComments();
        Task<int> postComment(Comment cmt);
        Task<Comment> putComment(Comment cmt);
        Task deleteComment(int id);
        Task<List<StudentComment>> getStudentCommentByStudentId(int id);
        Task deleteStudentComment(int id);
    }
}