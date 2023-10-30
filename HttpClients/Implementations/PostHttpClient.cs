using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Domain.DTOs;
using Domain.Models;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class PostHttpClient : IPostService
{
    private readonly HttpClient client;

    public PostHttpClient(HttpClient client)
    {
        this.client = client;
    }
    public async Task<ICollection<Post>> GetAsync(string? userName, string? titleContains, string? bodyContains)
    {
        HttpResponseMessage message = await client.GetAsync("/posts");
        string content = await message.Content.ReadAsStringAsync();
        if (!message.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
        ICollection<Post> posts = JsonSerializer.Deserialize<ICollection<Post>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return posts;
    }

    public async Task CreateAsync(PostCreationDto postCreationDto)
    {
        HttpResponseMessage message = await client.PostAsJsonAsync("/posts", postCreationDto);
        if (!message.IsSuccessStatusCode)
        {
            string content = await message.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }

    public async Task<Comment> AddCommentAsync(CommentCreationDto commentCreationDto)
    {
        HttpResponseMessage message = await client.PatchAsJsonAsync("/posts/hugy", commentCreationDto);
        if (!message.IsSuccessStatusCode)
        {
            string content = await message.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
        
        var responseContent = await message.Content.ReadAsStringAsync();

        Comment newlyCreatedComment = JsonSerializer.Deserialize<Comment>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

        return newlyCreatedComment;
    }

    public async Task<int> AddUpvoteAsync(UpvoteCreationDto upvoteCreationDto)
    {
        HttpResponseMessage message = await client.PatchAsJsonAsync("/posts/up", upvoteCreationDto);
        if (!message.IsSuccessStatusCode)
        {
            string content = await message.Content.ReadAsStringAsync();
            throw new Exception(content);
        }

        return upvoteCreationDto.Vote;
    }

    public async Task DeletePost(int postID)
    {
        HttpResponseMessage message = await client.DeleteAsync($"Posts/{postID}");
        if (!message.IsSuccessStatusCode)
        {
            string content = await message.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }
}