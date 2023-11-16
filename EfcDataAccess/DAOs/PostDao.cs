using Application.DaoInterfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace EfcDataAccess.DAOs;

public class PostDao : IPostDao
{
    private readonly ForumContext context;

    public PostDao(ForumContext context)
    {
        this.context = context;
    }
    public async Task<Post> CreateAsync(Post post)
    {
        EntityEntry<Post> newPost = await context.Posts.AddAsync(post);
        await context.SaveChangesAsync();
        return newPost.Entity;
    }

    public async Task<IEnumerable<Post>> GetAsync()
    {
        IEnumerable<Post> allPosts = await context.Posts.Include(p =>p.Owner).ToListAsync();
        return allPosts;
    }

    public async Task<IEnumerable<Comment>> GetCommentsForPost(int postId)
    {
        Console.WriteLine(postId);
        IEnumerable<Comment> comments = await context.Comments
            .Where(c => c.PostId == postId)
            .Include(c => c.Owner)
            .ToListAsync();
        foreach (var c in comments)
        {
            Console.WriteLine(c.CommentBody);
        }
        return comments;
    }

    public async Task<Comment> AddCommentAsync(Comment comment, Post post)
    {
        post.Comments.Add(comment);
        Post? existing = await context.Posts.FirstOrDefaultAsync(p => post.Id == p.Id);
        existing.Comments.Add(comment);
        //context.Posts.Remove(existing);
        //await context.Posts.AddAsync(post);
        context.Update(existing);
        await context.SaveChangesAsync();
        return comment;
    }

    public async Task<int> AddUpvoteAsync(int vote, Post post)
    {
        context.ChangeTracker.Clear();
        //post.UpVotes += vote;
        Post? existing = await context.Posts.FirstOrDefaultAsync(p => post.Id == p.Id);
        existing.UpVotes += vote;
        //context.Posts.Remove(existing);
        //await context.Posts.AddAsync(post);
        context.Posts.Update(existing);
        await context.SaveChangesAsync();
        Console.WriteLine("postdao" + vote);
        return vote;
    }

    public async Task<bool> DeletePost(int postId)
    {
        var existing = await context.Posts.Include(p => p.Comments).FirstOrDefaultAsync(p => postId == p.Id);
        context.Posts.Remove(existing);
        await context.SaveChangesAsync();
        return true;
    }
}