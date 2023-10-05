using Hackerspace.Shared.Models;

namespace Hackerspace.Server.Repos
{
    public class PostsRepoMock
    {
        private List<Post> posts;

        public PostsRepoMock()
        {
            posts = new List<Post>();
            posts.Add(new Post
            {
                Id = 1,
                Title = "Test 1",
                Text = "Test 1",
                Date = DateTime.Now,
            });
            
            posts.Add(new Post
            {
                Id = 2,
                Title = "Test 2",
                Text = "Test 2",
                Date = DateTime.Now,
            }); 
            
            posts.Add(new Post
            {
                Id = 3,
                Title = "Test 3",
                Text = "Test 3",
                Date = DateTime.Now,
            });
        }

        public List<Post> GetAll()
        {
            return posts;
        }

        public void InsertPost(Post post)
        {
            posts.Add(post);
        }

    }
}
