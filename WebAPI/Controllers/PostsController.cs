using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PostsController : ControllerBase
{
    private readonly IPostLogic postLogic;

    public PostsController(IPostLogic postLogic)
    {
        this.postLogic = postLogic;
    }

    [HttpPost]
    public async Task<ActionResult<Post>> CreateAsync([FromBody] PostCreationDto postCreationTdo)
    {
        try
        {
            Post newPost= await postLogic.CreateAsync(postCreationTdo);
            return Created($"posts/{newPost.Id}",newPost);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Post>>> GetAsync()
    {
        try
        {
            IEnumerable<Post> posts = await postLogic.GetAsync();
            return Ok(posts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpPatch]
    public async Task<ActionResult<Comment>> AddComment(CommentCreationDto commentCreationDto)
    {
        try
        {
            Console.WriteLine("CONTROLLER:"+commentCreationDto.CommentBody);
            Comment comment = await postLogic.AddCommentAsync(commentCreationDto);
            return Ok(comment);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500,e.Message);
        }
        
    }

    

    [HttpDelete, Route("/posts/{postID}")]
    public async Task<bool> DeletePost(int postID)
    {
        if (await postLogic.DeletePost(postID))
        {
            return true;
        }

        return false;
    }
}