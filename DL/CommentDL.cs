using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    public class CommentDL : ICommentDL
    {

        VolunteerContext vrc;
        public CommentDL(VolunteerContext vrc)
        {
            this.vrc = vrc;
        }

        //get
        public async Task<List<Comment>> getComments()
        {
            List<Comment> commentL = await vrc.Comments.Include(s => s.VolunteerType).Include(s => s.FromUser). ToListAsync(); 
            return commentL;
        }
        //getById
        public async Task<Comment> getCommentById(int id)
        {
            Comment comment = await vrc.Comments.FindAsync(id);
            return comment;
        }
        //post
        public async Task<int> postComment(Comment cmt)
        {
            await vrc.Comments.AddAsync(cmt);
            await vrc.SaveChangesAsync();
            return cmt.Id;
        }
        //put
        public async Task<Comment> putComment(Comment cmt)
        {
            Comment commentToUpdate = await vrc.Comments.FindAsync(cmt.Id);
            if (commentToUpdate == null)
                return null;
            vrc.Entry(commentToUpdate).CurrentValues.SetValues(cmt);
            await vrc.SaveChangesAsync();
            return cmt;
        }
        //delete
        public async Task deleteComment(int id)
        {
            Comment ct = await vrc.Comments.FindAsync(id);
            if (ct == null)
                throw new Exception();
             vrc.Comments.Remove(ct);
            await vrc.SaveChangesAsync();
        }

        public Task<List<Volunteering>> GetNotSet()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<List<StudentVolunteeringDTO>>> GetByVolunteeringId(int volunteeringId)
        {
            throw new NotImplementedException();
        }
    }
}
