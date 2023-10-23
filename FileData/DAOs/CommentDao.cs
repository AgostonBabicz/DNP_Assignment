using Application.DaoInterfaces;
using Domain.Models;

namespace DefaultNamespace.DAOs;

public class CommentDao : ICommentDao
{
    private readonly FileContext fileContext;
    
    public CommentDao(FileContext fileContext)
    {
        this.fileContext = fileContext;
    }
    
    public Task<Comment> CreateAsync(Comment comment)
    {
        int id = 1;
        if (fileContext.Comments.Any())
        {
            id = fileContext.Comments.Max(c => c.ID);
            id++;
        }
        comment.ID = id;
        fileContext.Comments.Add(comment);
        fileContext.SaveChanges();
        return Task.FromResult(comment);
    }

    public async Task<IEnumerable<Comment>> GetAsync()
    {
        IEnumerable<Comment> comments = fileContext.Comments.AsEnumerable();
        return comments;
    }
}