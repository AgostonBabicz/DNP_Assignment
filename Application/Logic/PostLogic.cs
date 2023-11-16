using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao postDao;
    private readonly IAuthDao authDao;

    public PostLogic(IPostDao postDao,IAuthDao authDao)
    {
        this.postDao = postDao;
        this.authDao = authDao;
    }

    public async Task<Post> CreateAsync(PostCreationDto postCreationDto)
    {
        User? user = await authDao.GetByUsernameAsync(postCreationDto.OwnerUsername);
        if (user==null)
        {
            throw new Exception($"The username {postCreationDto.OwnerUsername} cannot be found");
        }
        ValidatePost(postCreationDto);
        Post post = new Post(user.Id, postCreationDto.Title, postCreationDto.Body,DateTime.Now);
        Post newPost = await postDao.CreateAsync(post);
        return newPost;
    }

    private void ValidatePost(PostCreationDto postCreationDto)
    {
        if (postCreationDto.Title==null)
        {
            throw new Exception("The post needs to have a title!");
        }

        if (postCreationDto.Body == null)
        {
            throw new Exception("The body cannot be empty!");
        }
    }

    public async Task<IEnumerable<Post>> GetAsync()
    {
        IEnumerable<Post> posts = await postDao.GetAsync();
        return posts;
    }

    public async Task<IEnumerable<Comment>> GetCommentsForPost(int postId)
    {
        IEnumerable<Comment> comments = await postDao.GetCommentsForPost(postId);
        return comments;
    }
    

    public async Task<Comment> AddCommentAsync(CommentCreationDto commentCreationDto)
    {
        User? user = await authDao.GetByUsernameAsync(commentCreationDto.User);
        Post post = commentCreationDto.Post;
        Comment comment = new Comment(user.Id, commentCreationDto.CreationTime,
            commentCreationDto.CommentBody);
        return await postDao.AddCommentAsync(comment,post);
    }

    public async Task<int> AddUpvoteAsync(UpvoteCreationDto upvoteCreationDto)
    {
        User? user = await authDao.GetByUsernameAsync(upvoteCreationDto.Owner);
        return await postDao.AddUpvoteAsync(upvoteCreationDto.Vote,upvoteCreationDto.Post);
    }

    public async Task<bool> DeletePost(int postID)
    {
        if (await postDao.DeletePost(postID))
        {
            return true;
        }

        return false;
    }
}