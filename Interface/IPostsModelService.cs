using EdgeApi.Model;

namespace EdgeApi.Interface
{
    public interface IPostsModelService
    {
        IEnumerable<PostsModel> ListarPosts();
        PostsModel ListarPostsById(int id);
        PostsModel InsertarPost(PostsInsModel post);
        PostsModel ActualizarPost(PostsModel post, int id);
        void EliminarPost(int id);

    }
}
