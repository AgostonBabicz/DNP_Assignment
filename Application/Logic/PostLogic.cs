using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao postDao;
    private readonly IUserDao userDao;

    public PostLogic(IPostDao postDao,IUserDao userDao)
    {
        this.postDao = postDao;
        this.userDao = userDao;
    }

    public async Task<Post> CreateAsync(PostCreationDto postCreationDto)
    {
        User? user = await userDao.GetByUsernameAsync(postCreationDto.OwnerUsername);
        if (user==null)
        {
            throw new Exception($"The username {postCreationDto.OwnerUsername} cannot be found");
        }
        ValidatePost(postCreationDto);
        Post post = new Post(user, postCreationDto.Title, postCreationDto.Body,DateTime.Now);
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
}