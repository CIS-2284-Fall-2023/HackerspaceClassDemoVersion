using Hackerspace.Shared.Models;

namespace Hackerspace.Server.Interfaces
{
    public interface IPostsRepo
    {
        IEnumerable<Post> GetPosts(int page, int pageSize);
        Post? GetPost(int id);
        Post AddPost(Post post);
        void UpdatePost(Post post);
        void DeletePost(int id);
    }
}