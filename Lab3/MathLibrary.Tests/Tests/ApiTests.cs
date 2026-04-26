using System.Net.Http.Json;

namespace MathLibrary.Tests.Tests;

public class ApiTests
{
    HttpClient client = new HttpClient();

    [Fact]
    public async Task Get_Posts()
    {
        var data = await client.GetFromJsonAsync<object[]>("https://jsonplaceholder.typicode.com/posts");
        Assert.NotNull(data);
    }

    [Fact]
    public async Task Get_Post_By_Id()
    {
        var data = await client.GetFromJsonAsync<object>("https://jsonplaceholder.typicode.com/posts/1");
        Assert.NotNull(data);
    }

    [Fact]
    public async Task Create_Post()
    {
        var response = await client.PostAsJsonAsync("https://jsonplaceholder.typicode.com/posts",
            new { title = "test", body = "test", userId = 1 });

        Assert.True(response.IsSuccessStatusCode);
    }

    [Fact]
    public async Task Update_Post()
    {
        var response = await client.PutAsJsonAsync("https://jsonplaceholder.typicode.com/posts/1",
            new { id = 1, title = "updated" });

        Assert.True(response.IsSuccessStatusCode);
    }

    [Fact]
    public async Task Delete_Post()
    {
        var response = await client.DeleteAsync("https://jsonplaceholder.typicode.com/posts/1");
        Assert.True(response.IsSuccessStatusCode);
    }
}