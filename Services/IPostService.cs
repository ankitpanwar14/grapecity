using BlogApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Services
{
    public interface IPostService
    {
        IEnumerable<Post> getAllPost();

        Task<Post> addPost(Post post);

        Task<Post> getPostById(int id);

        Task<Post> modifyPost(int id, Post post);

        Task<Post> deletePostById(int id);
    }
}
