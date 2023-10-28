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
    //ez egyelore kuka csinalok jobbat
   /* public async Task AddCommentAsync(CommentCreationDto commentCreationDto)
    {
        HttpResponseMessage message = await client.PatchAsJsonAsync("/posts", commentCreationDto);
        if (!message.IsSuccessStatusCode)
        {
            string content = await message.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }*/
    
   /* public async Task<Comment> AddCommentAsync(CommentCreationDto commentCreationDto)
    {                                              //gpt vegig
        HttpResponseMessage message = await client.PatchAsJsonAsync("/posts", commentCreationDto);
        if (!message.IsSuccessStatusCode)
        {
            string content = await message.Content.ReadAsStringAsync();
            throw new Exception(content); //nincs ilyen sir a szaja gpt urasag kegyelmezett meg
        }
    
        // deserialize az uj commentet a responsnak a bodyjabol es vissza etetem vele
        Comment newlyCreatedComment = JsonSerializer.Deserialize<Comment>( //agyhalott vagyok ilyet itt igy nem lehet
        })!; //beszart
    
        return newlyCreatedComment; //barcsak
    }*/
   //hat nem sikerult ez kurva szar itthagyom h a gondolat menetm meg otlet ne vesszen el

   public async Task<Comment> AddCommentAsync(CommentCreationDto commentCreationDto)
   {
       HttpResponseMessage message = await client.PatchAsJsonAsync("/posts", commentCreationDto);
       if (!message.IsSuccessStatusCode)
       {
           throw new Exception("failed to add comment"); // kis subidubi
       }
    
       // nem tom igy mukodik e az async elgetes de ha jol ertem igen
       var responseContent = await message.Content.ReadAsStringAsync();

       // na igy mar lehet deserializolni es returnolni
       Comment newlyCreatedComment = JsonSerializer.Deserialize<Comment>(responseContent, new JsonSerializerOptions
       {
           PropertyNameCaseInsensitive = true
       })!;

       return newlyCreatedComment;
   }
   //ez szarra lett chat gpt zve

   
}