using Hackerspace.Server.Interfaces;
using Hackerspace.Shared.Models;
using Microsoft.AspNetCore.Http;
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
        public IEnumerable<Post> GetAllPosts(int page, int pageSize)
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
        public void PostPost(Post post)
        {
            _postsRepo.AddPost(post);
        }

        [HttpPut]
        public void PutPost(Post post) 
        {
            _postsRepo.UpdatePost(post);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public void DeletePost(int id)
        {
            _postsRepo.DeletePost(id);
        }
    }
}
