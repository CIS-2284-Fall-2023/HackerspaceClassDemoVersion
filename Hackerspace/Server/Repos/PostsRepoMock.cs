using Hackerspace.Shared.Models;
using System.Collections;

namespace Hackerspace.Server.Repos
{
    public class PostsRepoMock
    {
        private List<Post> posts;

        public PostsRepoMock()
        {
            posts = new List<Post>();

            for (int i = 0; i < 105; i++) 
            {
                posts.Add(new Post
                {
                    Id = i,
                    Title = $"Test {i}",
                    Text = $"Test {i}",
                    Date = DateTime.Now,
                });
            }
        }

        public IEnumerable<Post> GetPosts(int page, int pageSize)
        {
            return posts.Skip((page-1)*pageSize).Take(pageSize);
        }

        public Post? GetPost(int id)
        {
            return posts.Where(p=>p.Id==id).FirstOrDefault();
        }

        public void InsertPost(Post post)
        {
            posts.Add(post);
        }

    }
}
