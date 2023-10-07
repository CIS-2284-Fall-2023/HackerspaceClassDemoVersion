using Hackerspace.Server.Interfaces;
using Hackerspace.Shared.Models;

namespace Hackerspace.Server.Mocks
{
    /// <summary>
    /// Mock of a posts repository. 
    /// Creates 37 random posts. 
    /// Provides full CRUD capability.
    /// Id field simulates automatic incrementation.
    /// </summary>
    public class PostsRepoMock : IPostsRepo
    {
        private List<Post> posts;
        /// <summary>
        /// Mock for PostsRepo
        /// </summary>
        public PostsRepoMock()
        {
            posts = new List<Post>();
            for(int i =  1; i < 37; i++)
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

        /// <summary>
        /// Returns a page of posts given page and pageSize. Page starts with page 1.
        /// </summary>
        /// <param name="page">Page. Page 1 is the first page.</param>
        /// <param name="pageSize">Number of posts to return.</param>
        /// <returns>A IEnumerable of Post with pageSize posts in it.</returns>
        public IEnumerable<Post> GetPosts(int page, int pageSize)
        {
            return posts.OrderByDescending(p=>p.Date).Skip((page-1)*pageSize).Take(pageSize);
        }

        /// <summary>
        /// Gets one post given an id for that post.
        /// </summary>
        /// <param name="id">Id of the post desired.</param>
        /// <returns>A single post.</returns>
        public Post? GetPost(int id)
        {
            return posts.Where(p => p.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Adds a post.
        /// </summary>
        /// <param name="post">The post to add or update.</param>
        /// <returns>Post with updagted id field.</returns>
        public Post AddPost(Post post)
        {
            post.Id = posts.Count(); //Simulate incrementing id
            posts.Add(post);
            return post;//Return post so calling function can get current id
        }

        /// <summary>
        /// Updates post based on id
        /// </summary>
        /// <param name="post">Post to update</param>
        public void UpdatePost(Post post)
        {
            // find post in current list
            // if found update each element
            Post? currentPost = posts.Find(x => x.Id == post.Id);
            if (currentPost != null)
            {
                currentPost.Date = DateTime.Now;
                currentPost.Title = post.Title;
                currentPost.Text = post.Text;
                currentPost.Date = DateTime.Now;
            }          
        }

        /// <summary>
        /// Deletes a post with the given id.
        /// </summary>
        /// <param name="id">Id of post to delete.</param>
        public void DeletePost(int id)
        {
            Post? post_to_remove = posts.FirstOrDefault(p => p.Id == id);
            if (post_to_remove != null)
            {
                posts.Remove(post_to_remove);
            }
        }

    }
}
