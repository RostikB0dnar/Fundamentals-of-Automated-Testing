using System.Net;

namespace MathLibrary.Tests;

public class ApiSmokeTests
{
    private readonly HttpClient _client = new HttpClient();

    [Fact]
    public async Task Get_AllBookings_ShouldReturn200()
    {
        var response = await _client.GetAsync("https://restful-booker.herokuapp.com/booking");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}