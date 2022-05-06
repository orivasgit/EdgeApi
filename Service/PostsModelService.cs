using EdgeApi.Interface;
using EdgeApi.Model;
using System.Text.Json;

namespace EdgeApi.Service
{
    public class PostsModelService : IPostsModelService
    {
        private readonly IConfiguration _configuration;

        public PostsModelService(IConfiguration configuration) { _configuration = configuration; }
        public IEnumerable<PostsModel> ListarPosts()
        {
            string result;
            IEnumerable<PostsModel>? posts;

            var client = new HttpClient();
            var url = _configuration.GetConnectionString("urlApi");
            client.BaseAddress = new System.Uri(url);
            HttpResponseMessage response;

            response = client.GetAsync("posts").Result;
            result = response.Content.ReadAsStringAsync().Result;
            posts = JsonSerializer.Deserialize<IEnumerable<PostsModel>>(result);


            client.Dispose();
            return posts;
        }

        public PostsModel ListarPostsById(int id)
        {
            string result;
            PostsModel? posts;

            var client = new HttpClient();
            var url = _configuration.GetConnectionString("urlApi");
            client.BaseAddress = new System.Uri(url);
            HttpResponseMessage response;

            response = client.GetAsync("posts/" + id).Result;
            result = response.Content.ReadAsStringAsync().Result;
            posts = JsonSerializer.Deserialize<PostsModel>(result);


            client.Dispose();
            return posts;

        }
        public PostsModel InsertarPost(PostsInsModel post)
        {

            string result;
            PostsModel? posts;

            var client = new HttpClient();
            var url = _configuration.GetConnectionString("urlApi");
            client.BaseAddress = new System.Uri(url);
            HttpResponseMessage response;

            response = client.PostAsJsonAsync("posts/", post).Result;
            result = response.Content.ReadAsStringAsync().Result;
            posts = JsonSerializer.Deserialize<PostsModel>(result);


            client.Dispose();
            return posts;


        }

        public PostsModel ActualizarPost(PostsModel post, int id)
        {
            string result;
            PostsModel? posts;

            var client = new HttpClient();
            var url = _configuration.GetConnectionString("urlApi");
            client.BaseAddress = new System.Uri(url);
            HttpResponseMessage response;

            response = client.PutAsJsonAsync("posts/" + id, post).Result;
            result = response.Content.ReadAsStringAsync().Result;
            posts = JsonSerializer.Deserialize<PostsModel>(result);


            client.Dispose();
            return posts;
        }


        public void EliminarPost(int id)
        {
            string result;
            PostsModel? posts;

            var client = new HttpClient();
            var url = _configuration.GetConnectionString("urlApi");
            client.BaseAddress = new System.Uri(url);
            HttpResponseMessage response;

            response = client.DeleteAsync("posts/" + id).Result;
            result = response.Content.ReadAsStringAsync().Result;
            posts = JsonSerializer.Deserialize<PostsModel>(result);

            client.Dispose();
            
        }
    }
}
