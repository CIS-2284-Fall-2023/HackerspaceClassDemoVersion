using Hackerspace.Server.Interfaces;
using Hackerspace.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hackerspace.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostsRepo _postsRepo;

        public PostsController(IPostsRepo postsRepo)
        {
                _postsRepo = postsRepo;
        }

        [HttpGet]
        [Route("{page:int}/{pageSize:int}")]
        public IEnumerable<Post> GetPosts(int page, int pageSize)
        {
            return _postsRepo.GetPosts(page,pageSize);
        }

        [HttpGet]
        [Route("{id:int}")]
        public Post? GetPost(int id)
        {
            return _postsRepo.GetPost(id);
        }

        [HttpPost] 
        public Post Add(Post post)
        {
            Post updatedPost = _postsRepo.AddPost(post);
            return updatedPost;
        }

        [HttpPut]
        public void Update(Post post)
        {
            _postsRepo.UpdatePost(post);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public void Delete(int id)
        {
            _postsRepo.DeletePost(id);
        }
    }
}
