using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface ICommentBL
    {
        Task deleteComment(int id);
        Task<Comment> getCommentById(int id);
        Task<List<Comment>> getComments();
        Task<int> postComment(Comment cmt);
        Task<Comment> putComment(Comment cmt);
    }
}