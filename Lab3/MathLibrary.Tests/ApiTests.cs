using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace MathLibrary.Tests;

public class ApiTests
{
    private readonly HttpClient _client;
    
    public ApiTests()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("https://restful-booker.herokuapp.com/");
        _client.DefaultRequestHeaders.Add("Cookie", "token=abc123");
    }
    
    [Fact]
    public async Task Get_AllBookings_Status200()
    {
        var response = await _client.GetAsync("booking");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Get_AllBookings_NotEmpty()
    {
        var response = await _client.GetAsync("booking");
        var content = await response.Content.ReadAsStringAsync();

        Assert.False(string.IsNullOrEmpty(content));
    }

    [Fact]
    public async Task Get_AllBookings_IsArray()
    {
        var response = await _client.GetAsync("booking");
        var content = await response.Content.ReadAsStringAsync();

        Assert.StartsWith("[", content);
    }

    [Fact]
    public async Task Get_AllBookings_ContainsBookingId()
    {
        var response = await _client.GetAsync("booking");
        var content = await response.Content.ReadAsStringAsync();

        Assert.Contains("bookingid", content);
    }

    [Fact]
    public async Task Get_AllBookings_ResponseTime()
    {
        var start = DateTime.Now;
        await _client.GetAsync("booking");
        var duration = DateTime.Now - start;

        Assert.True(duration.TotalSeconds < 2);
    }
    
    [Fact]
    public async Task Get_BookingById_Status200()
    {
        var response = await _client.GetAsync("booking/1");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Get_BookingById_ContainsFirstname()
    {
        var response = await _client.GetAsync("booking/1");
        var content = await response.Content.ReadAsStringAsync();

        Assert.Contains("firstname", content);
    }

    [Fact]
    public async Task Get_BookingById_ContainsLastname()
    {
        var response = await _client.GetAsync("booking/1");
        var content = await response.Content.ReadAsStringAsync();

        Assert.Contains("lastname", content);
    }

    [Fact]
    public async Task Get_BookingById_NotEmpty()
    {
        var response = await _client.GetAsync("booking/1");
        var content = await response.Content.ReadAsStringAsync();

        Assert.False(string.IsNullOrEmpty(content));
    }

    [Fact]
    public async Task Get_BookingById_InvalidId_Returns404()
    {
        var response = await _client.GetAsync("booking/999999");
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    
    [Fact]
    public async Task CreateBooking_ShouldReturn200()
    {
        var body = new
        {
            firstname = "Test",
            lastname = "User",
            totalprice = 100,
            depositpaid = true,
            bookingdates = new
            {
                checkin = "2024-01-01",
                checkout = "2024-01-10"
            },
            additionalneeds = "Breakfast"
        };

        var content = new StringContent(
            JsonConvert.SerializeObject(body),
            Encoding.UTF8,
            "application/json"
        );

        var response = await _client.PostAsync("booking", content);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async Task UpdateBooking_WithoutAuth_ShouldFail()
    {
        var response = await _client.PutAsync("booking/1", null);
        Assert.True(response.StatusCode == HttpStatusCode.Forbidden ||
                    response.StatusCode == HttpStatusCode.MethodNotAllowed);
    }
    
    [Fact]
    public async Task DeleteBooking_WithoutAuth_ShouldFail()
    {
        var response = await _client.DeleteAsync("booking/1");

        Assert.True(response.StatusCode == HttpStatusCode.Forbidden ||
                    response.StatusCode == HttpStatusCode.MethodNotAllowed);
    }
}