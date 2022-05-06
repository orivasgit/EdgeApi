using EdgeApi.Interface;
using EdgeApi.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EdgeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {

        private IPostsModelService _posts;
        public PostsController(IPostsModelService posts)
        {
            _posts = posts;
        }

        // GET: api/<PostsController>
        [HttpGet]
        public IEnumerable<PostsModel> Get()
        {
            return _posts.ListarPosts();
        }

        // GET api/<PostsController>/5
        [HttpGet("{id}")]
        public PostsModel Get(int id)
        {
            return _posts.ListarPostsById(id);
        }

        // POST api/<PostsController>
        [HttpPost]
        public PostsModel Post([FromBody] PostsInsModel post)
        {
            return _posts.InsertarPost(post);
        }

        // PUT api/<PostsController>/5
        [HttpPut("{id}")]
        public PostsModel Put(int id, [FromBody] PostsModel post)
        {
            return _posts.ActualizarPost(post, id);
        }

        // DELETE api/<PostsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
             _posts.EliminarPost(id);
        }
    }
}
