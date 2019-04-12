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
                    Catagory = model.Catagory,
                    Text = model.Text,
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
                                    PostCommentId = e.PostCommentId,
                                    Catagory = e.Catagory,
                                   
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
                        .Single(e => e.EditorId == _userId && e.PostCommentId == noteId);

                return
                    new PostCommentDetail
                    {
                        PostCommentId = entity.PostCommentId,
                        Catagory = entity.Catagory,
                        Text = entity.Text,
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
                   .Single(e => e.PostCommentId == model.PostCommentId && e.EditorId == _userId);

                entity.Catagory = model.Catagory;
                entity.Text = model.Text;
                

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
                   .Single(e => e.EditorId == _userId && e.PostCommentId == id);

                ctx.PostComments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
