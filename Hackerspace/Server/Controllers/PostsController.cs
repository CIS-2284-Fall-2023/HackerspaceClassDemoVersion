using Hackerspace.Server.Repos;
using Hackerspace.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hackerspace.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly PostsRepoMock _postsRepo;

        public PostsController(PostsRepoMock postsRepo)
        {
                _postsRepo = postsRepo;
        }

        [HttpGet]
        public List<Post> GetAllPosts()
        {
            return _postsRepo.GetAll();
        }

        [HttpPost] 
        public void InsertPost(Post post)
        {
            _postsRepo.InsertPost(post);
        }
    }
}
