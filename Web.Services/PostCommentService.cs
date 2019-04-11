using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.Data;
using Wiki.Models;

namespace Wiki.Services
{
    public class PostCommentService
    {
        private readonly Guid _userId;
        public PostCommentService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreatePostComment(PostCommentCreate model)
        {
            var entity =
                new PostComment()
                {
                    EditorId = _userId,
                    CommentCatagory = model.CommentCatagory,
                    CommentText = model.CommentText,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.PostComments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<PostCommentListItem> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .PostComments
                        .Where(e => e.EditorId == _userId)
                        .Select(
                            e =>
                                new PostCommentListItem
                                {
                                    CommentId = e.CommentId,
                                    CommentCatagory = e.CommentCatagory,
                                   
                                }
                        );

                return query.ToArray();
            }
        }
        public PostCommentDetail GetPostCommentById(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PostComments
                        .Single(e => e.EditorId == _userId && e.CommentId == noteId);

                return
                    new PostCommentDetail
                    {
                        CommentId = entity.CommentId,
                        CommentCatagory = entity.CommentCatagory,
                        CommentText = entity.CommentText,
                    };
            }
        }
        public bool UpdateComment(PostCommentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                ctx
                   .PostComments
                   .Single(e => e.CommentId == model.CommentId && e.EditorId == _userId);

                entity.CommentCatagory = model.CommentCatagory;
                entity.CommentText = model.CommentText;
                

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeletePostComment(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                ctx
                   .PostComments
                   .Single(e => e.EditorId == _userId && e.CommentId == id);

                ctx.PostComments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
