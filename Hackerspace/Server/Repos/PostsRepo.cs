using Hackerspace.Server.Data;
using Hackerspace.Server.Interfaces;
using Hackerspace.Shared.Models;

namespace Hackerspace.Server.Repos
{
    public class PostsRepo : IPostsRepo
    {
        private ApplicationDbContext _context;

        public PostsRepo(ApplicationDbContext context) 
        {
            _context = context;
        }
        public Post AddPost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
            return post; //TODO: Verify Id field is autoincremented.
        }

        public void DeletePost(int id)
        {
            Post? post_to_remove = _context.Posts.Where(p => p.Id == id).FirstOrDefault();
            if (post_to_remove != null)
            {
                _context.Posts.Remove(post_to_remove);
            }
            _context.SaveChanges();
        }

        public Post? GetPost(int id)
        {
            return _context.Posts.Where(p => p.Id == id).FirstOrDefault();
        }

        public IEnumerable<Post> GetPosts(int page, int pageSize)
        {
            return _context.Posts.OrderByDescending(p => p.Date).Skip((page - 1) * pageSize).Take(pageSize);
        }

        public void UpdatePost(Post post)
        {
            //find current post
            Post? currentPost = _context.Posts.Where(p => p.Id == post.Id).FirstOrDefault();

            //if found update each element
            if (currentPost != null)
            {
                currentPost.Title = post.Title;
                currentPost.Text = post.Text;
                currentPost.Date = post.Date;
            }
            _context.SaveChanges();
        }
    }
}
