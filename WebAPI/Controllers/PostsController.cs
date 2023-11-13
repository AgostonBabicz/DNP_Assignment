using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

    [HttpPatch,Route("/posts/comment")]
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

    [HttpPatch,Route("/posts/up")]
    public async Task<int> AddUpvote(UpvoteCreationDto upvoteCreationDto)
    {
        try
        {
            Console.WriteLine("controller" + upvoteCreationDto.Vote);
            int vote = await postLogic.AddUpvoteAsync(upvoteCreationDto);
            return vote;
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
            return -1;
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