﻿using System;
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
                    PostCommentId = model.PostCommentId,
                    Text = model.Text,
                    CreadtedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Threads.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ThreadListItem> GetThreads(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Threads
                        .Where(e => e.PostCommentId == id)
                        .Select(
                            e =>
                                new ThreadListItem
                                {
                                    ThreadId = e.ThreadId,
                                    Text = e.Text,
                                    CreatedUtc = e.CreadtedUtc
                                }
                        );

                return query.ToArray();
            }
        }
        public ThreadDetail GetThreadById(int threadId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Threads
                        .Single(e => e.ThreadId == threadId);

                return
                    new ThreadDetail
                    {
                        ThreadId = entity.ThreadId,
                        Text = entity.Text,
                        CreatedUtc = entity.CreadtedUtc,
                        ModifiedUtc = entity.ModifiedUtc,
                        PostCommentId =         entity.PostCommentId
                     

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
                   .Single(e => e.EditorId == _userId && e.ThreadId == model.ThreadId);

                
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
