using System.Net.Http.Json;

var client = new HttpClient
{
    BaseAddress = new Uri("https://jsonplaceholder.typicode.com/")
};
var post = await client.GetFromJsonAsync<Post>("posts/1");
Console.WriteLine(post?.Title);

var addPost = await client.PostAsJsonAsync("posts", new Post(1, 1, "New Post", "This post added for test"));
var addedPost = await addPost.Content.ReadFromJsonAsync<Post>();
Console.WriteLine($"Added Post - {addedPost?.Id} - {addedPost?.Title}");

var updatePost = await client.PutAsJsonAsync("posts/1", new Post(1, 1, "Updated Post", "This post updated for test"));
var updatedPost = await updatePost.Content.ReadFromJsonAsync<Post>();
Console.WriteLine($"Updated Post - {updatedPost?.Id} - {updatedPost?.Title}");

var deletePost = await client.DeleteAsync("posts/1");
Console.WriteLine($"Deleted Post - {deletePost.StatusCode}");

record Post(int UserId, int Id, string Title, string Body);