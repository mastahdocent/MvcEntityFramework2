using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rozdzial2_C.Models
{
    public class PostModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }

    public class PostService
    {
        private readonly EFCDbContext _context;

        public PostService(EFCDbContext context)
        {
            this._context = context;
        }

        public bool AddPost(PostModel postModel)
        {
            _context.Posts.Add(postModel);
            return _context.SaveChanges() > 0;
        }

        public bool RemovePost(int id)
        {
            var post = this.GetPost(id);
            _context.Posts.Remove(post);
            return _context.SaveChanges() > 0;
        }

        public bool UpdatePost(PostModel postModel)
        {
            _context.Posts.Update(postModel);
            return _context.SaveChanges() > 0;
        }

        public PostModel GetPost(int id)
        {
            return _context.Posts.Single(x => x.ID == id);
        }

        public List<PostModel> GetPosts()
        {
            return _context.Posts.ToList();
        }
    }
}
