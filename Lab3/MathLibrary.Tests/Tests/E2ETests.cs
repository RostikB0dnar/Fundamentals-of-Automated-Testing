using MathLibrary.Tests.Core;

namespace MathLibrary.Tests.Tests;

public class E2ETests : BaseTest
{
    [Fact]
    public async Task User_Searches_QA_Jobs()
    {
        await Page.GotoAsync("https://jobs.dou.ua/");

        await Page.FillAsync("input[name='search']", "QA");
        await Page.PressAsync("input[name='search']", "Enter");

        await Page.WaitForSelectorAsync(".vacancy");

        var results = await Page.Locator(".vacancy").CountAsync();
        Assert.True(results > 0);
    }
}