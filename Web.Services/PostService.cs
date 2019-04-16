using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.Models;
using Wiki.Data;


namespace Wiki.Services
{
    public class PostService
    {
        private readonly Guid _userId;
        public PostService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreatePost(PostCreate model)
        {
            var entity =
                new Post()
                {
                    EditorId = _userId,
                    Catagory = model.Catagory,
                    Text = model.Text,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<PostListItem> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Posts.Select(
                            e =>
                                new PostListItem
                                {
                                    PostId = e.PostId,
                                    Catagory = e.Catagory,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }
        public PostDetail GetPostById(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.PostId == noteId);

                return
                    new PostDetail
                    {
                        PostId = entity.PostId,
                        Catagory = entity.Catagory,
                        Text = entity.Text,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc

                    };
            }
        }
        public bool UpdateNote(PostEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                ctx
                   .Posts
                   .Single(e => e.PostId == model.PostId && e.EditorId == _userId);

                entity.Catagory = model.Catagory;
                entity.Text = model.Text;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeletePost(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                ctx
                   .Posts
                   .Single(e => e.EditorId == _userId && e.PostId == id);

                ctx.Posts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
