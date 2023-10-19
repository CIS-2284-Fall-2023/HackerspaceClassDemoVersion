using Hackerspace.Server.Interfaces;
using Hackerspace.Shared.Models;
using System.Collections;

namespace Hackerspace.Server.Mocks
{
    public class PostsRepoMock : IPostsRepo
    {
        private List<Post> posts;

        public PostsRepoMock()
        {
            posts = new List<Post>();

            for (int i = 1; i < 105; i++)
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
            return posts.OrderByDescending(p => p.Date).Skip((page - 1) * pageSize).Take(pageSize);
        }

        public Post? GetPost(int id)
        {
            return posts.Where(p => p.Id == id).FirstOrDefault();
        }


        public Post AddPost(Post post)
        {
            post.Id = posts.Count + 1;
            posts.Add(post);
            return post;
        }

        public void UpdatePost(Post post)
        {
            //find current post
            Post? currentPost = posts.Find(p => p.Id == post.Id);

            //if found update each element
            if (currentPost != null)
            {
                currentPost.Title = post.Title;
                currentPost.Text = post.Text;
                currentPost.Date = post.Date;
            }
        }

        public void DeletePost(int id)
        {
            Post? post_to_remove = posts.Where(p => p.Id == id).FirstOrDefault();
            if (post_to_remove != null)
            {
                posts.Remove(post_to_remove);
            }
        }
    }
}
