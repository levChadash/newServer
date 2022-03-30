using DL;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CommentBL : ICommentBL
    {
        ICommentDL commentdl;
        public CommentBL(ICommentDL commentdl)
        {
            this.commentdl = commentdl;
        }
        //get
        public async Task<List<Comment>> getComments()
        {
            return await commentdl.getComments();
        }
        //getById
        public async Task<Comment> getCommentById(int id)
        {
            return await commentdl.getCommentById(id);
        }
        //post
        public async Task<int> postComment(Comment cmt)
        {

            return await commentdl.postComment(cmt);
        }
        //put
        public async Task<Comment> putComment(Comment cmt)
        {
            return await commentdl.putComment(cmt);
        }
        //delete
        public async Task deleteComment(int id)
        {

            await commentdl.deleteComment(id);
        }

    }
}
