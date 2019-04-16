using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.Data;
using Wiki.Models.Thread;

namespace Wiki.Services
{
    public class ThreadService
    {
        private readonly Guid _userId;
        public ThreadService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateThread(ThreadCreate model)
        {
            var entity =
                new Thread()
                {
                    EditorId = _userId,
                    Text = model.Text,
                    CreadtedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Threads.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ThreadListItem> GetThreads()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Threads
                        .Where(e => e.EditorId == _userId)
                        .Select(
                            e =>
                                new ThreadListItem
                                {
                                    ThreadId = e.ThreadId,
                                    CreatedUtc = e.CreadtedUtc
                                }
                        );

                return query.ToArray();
            }
        }
        public ThreadDetail GetThreadById(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Threads
                        .Single(e => e.EditorId == _userId && e.ThreadId == noteId);

                return
                    new ThreadDetail
                    {
                        ThreadId = entity.ThreadId,
                        Text = entity.Text,
                        CreatedUtc = entity.CreadtedUtc,
                        ModifiedUtc = entity.ModifiedUtc

                    };
            }
        }
        public bool UpdateThread(ThreadEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                ctx
                   .Threads
                   .Single(e => e.ThreadId == model.ThreadId && e.EditorId == _userId);

                
                entity.Text = model.Text;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteThread(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                ctx
                   .Threads
                   .Single(e => e.EditorId == _userId && e.ThreadId == id);

                ctx.Threads.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
