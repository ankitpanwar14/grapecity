using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Model;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Services
{
    public class PostService : IPostService
    {
        private readonly postDBContext _context;

        public PostService(postDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Post> getAllPost()
        {
            return _context.Posts;
        }

        public async Task<Post> addPost(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return post;
        }

        public async Task<Post> getPostById(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            return post;
        }

        public async Task<Post> modifyPost(int id, Post post)
        {
            _context.Entry(post).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return post;
        }

        public async Task<Post> deletePostById(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return null;
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return post;
        }
    }
}
