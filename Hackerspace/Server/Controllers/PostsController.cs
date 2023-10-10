using Hackerspace.Server.Interfaces;
using Hackerspace.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hackerspace.Server.Controllers
{
    [Route("api/[controller]")]
    public class PostsController:ControllerBase
    {
        private readonly IPostsRepo _postRepo;

        public PostsController(IPostsRepo postsRepo)
        {
            _postRepo = postsRepo;     
        }

        [HttpGet]
        [Route("{page:int}/{pageSize:int}")]
        public IEnumerable<Post> GetPosts(int page, int pageSize)
        {
            return _postRepo.GetPosts(page, pageSize);
        }

        [HttpGet]
        [Route("{id:int}")]
        public Post? GetPost(int id)
        {
            return _postRepo.GetPost(id);
        }

        [HttpPost]
        public Post Add(Post post)
        {
            Post updatedPost = _postRepo.AddPost(post);
            return updatedPost;
        }

        [HttpPut]
        public void Update(Post post)
        {
            _postRepo.UpdatePost(post);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public void Delete(int id)
        {
            _postRepo.DeletePost(id);
        }
    }
}
